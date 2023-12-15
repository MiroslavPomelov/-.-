using OfficeOpenXml;

namespace WaybillFormation
{
    static class TableOperator
    {
        public static void CreateTable(List<Goods> data, string excelFilePath)
        {
            ExcelPackage newBook = new ExcelPackage(excelFilePath);
            ExcelWorksheet dataTable;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            bool isSheetExists = false;
            foreach (ExcelWorksheet worksheet in newBook.Workbook.Worksheets)
            {
                if (worksheet.Name == "Поставки товаров со склада")
                {
                    isSheetExists = true;
                }
            }
            if (isSheetExists)
            {
                dataTable = newBook.Workbook.Worksheets["Поставки товаров со склада"];
            }
            else
            {
                dataTable = newBook.Workbook.Worksheets.Add("Поставки товаров со склада");
            }


            for (int i = 0; i < data.Count; i++)
            {
                dataTable.Cells[i + 1, 1].Value = data[i].Name;
                dataTable.Cells[i + 1, 2].Value = data[i].Quantity;
                dataTable.Cells[i + 1, 3].Value = data[i].Price;
                dataTable.Cells[i + 1, 4].Value = data[i].Provider;
                dataTable.Cells[i + 1, 5].Value = data[i].Recipient;
                dataTable.Cells[i + 1, 6].Value = data[i].Date.Date;
            }

            newBook.Save();
        }
    }
}
