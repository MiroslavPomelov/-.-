using OfficeOpenXml;
using Word = Microsoft.Office.Interop.Word;

namespace WaybillFormation
{
    static class WaybillCreator
    {
        public static void GetData(string excelFilePath)
        {
            ExcelPackage newBook = new ExcelPackage(excelFilePath);
            ExcelWorksheet dataTable = newBook.Workbook.Worksheets["Поставки товаров со склада"];

            List<Goods> data = new List<Goods>();

            for (int i = 1; i <= dataTable.Dimension.Rows; i++)
            {
                string goodName = dataTable.Cells[i, 1].Text;
                int goodQuantity = int.Parse(dataTable.Cells[i, 2].Text);
                int goodPrice = int.Parse(dataTable.Cells[i, 3].Text);
                string goodProvider = dataTable.Cells[i, 4].Text;
                string goodRecipient = dataTable.Cells[i, 5].Text;
                DateTime goodDate = DateTime.Parse(dataTable.Cells[i, 6].Text);

                data.Add(new Goods(goodName, goodQuantity, goodPrice, goodProvider, goodRecipient, goodDate));
            }

            foreach (Goods good in data)
            {
                Console.WriteLine($"{good.Name} {good.Price} {good.Quantity} {good.Provider} {good.Recipient} {good.Date}");
            }

            FormWaybill(data);
        }
        public static void FormWaybill(List<Goods> data)
        {
            Dictionary<string, List<Goods>> compliances = new Dictionary<string, List<Goods>>();
            HashSet<DateTime> dates = new HashSet<DateTime>();

            foreach (Goods good in data)
            {
                dates.Add(good.Date);
                if (compliances.ContainsKey(good.Recipient))
                {
                    compliances[good.Recipient].Add(good);
                }
                else
                {
                    compliances.Add(good.Recipient, new List<Goods>() { good });
                }
            }

            List<Goods> temp = new List<Goods>();
            foreach (string recipient in compliances.Keys) //Мебельный магазин
            {
                foreach (DateTime date in dates) // 10.10.2023
                {
                    foreach (Goods good in data)
                    {
                        if (good.Date == date && good.Recipient == recipient)
                        {
                            temp.Add(good);
                        }
                    }
                    WriteWaybill(temp);
                    temp.Clear();
                }
            }
        }

        public static void WriteWaybill(List<Goods> temp)
        {
            Random rand = new Random();
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open($"{Directory.GetCurrentDirectory()}\\Товарная накладная.docx");

            try
            {
                string fileName = $"{Directory.GetCurrentDirectory()}\\Накладная от {temp[0].Date.Year}.{temp[0].Date.Month}.{temp[0].Date.Day}. Получатель - {temp[0].Recipient}.docx";
                doc.SaveAs(fileName);
                doc.Close();

                doc = wordApp.Documents.Open(fileName);

                //Word.Range range = doc.Content; При единоразовом определении диапазона переименовывать за один раз все строки он не хотел
                //Видимо проблема была в курсоре, якобы он устанавливался в конец и больше теги не видел, но это не точно
                //Поэтому было принято решение каждый раз вызывать диапазон, а от него уже методы замены
                doc.Content.Find.Execute("<NUM>", ReplaceWith: $"{rand.Next(100000, 120000)}");
                doc.Content.Find.Execute("<DATE>", ReplaceWith: $"{temp[0].Date.ToShortDateString()}");
                doc.Content.Find.Execute("<PROVIDER>", ReplaceWith: $"{temp[0].Provider}");
                doc.Content.Find.Execute("<RECIPIENT>", ReplaceWith: $"{temp[0].Recipient}");
                doc.Content.Find.Execute("<RECIPIENT>", ReplaceWith: $"{temp[0].Recipient}");

                Word.Table table = doc.Tables[1];

                int summ = 0;

                // Заполнение ячеек таблицы
                for (int i = 1; i <= temp.Count; i++)
                {
                    table.Rows.Add();
                    table.Cell(i + 1, 1).Range.Text = i.ToString();
                    table.Cell(i + 1, 2).Range.Text = temp[i - 1].Name;
                    table.Cell(i + 1, 3).Range.Text = temp[i - 1].Quantity.ToString();
                    table.Cell(i + 1, 4).Range.Text = temp[i - 1].Price.ToString();

                    int total = temp[i - 1].Price * temp[i - 1].Quantity;

                    table.Cell(i + 1, 5).Range.Text = total.ToString();

                    summ += total;
                }

                doc.Content.Find.Execute("<SUMM>", ReplaceWith: $"{summ}");
                doc.Content.Find.Execute("<SUMM>", ReplaceWith: $"{summ}");
                doc.Content.Find.Execute("<QUANTITY>", ReplaceWith: $"{temp.Count}");

                doc.SaveAs(fileName);
                Console.WriteLine($"Документ: {fileName} успешно создан");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                doc.Close();
                wordApp.Quit();
            }
        }
    }
}
