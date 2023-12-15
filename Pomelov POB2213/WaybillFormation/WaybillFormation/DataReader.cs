using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace WaybillFormation
{
    static class DataReader
    {
        public static List<Goods> GetDataFromCSV(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            CsvReader csvRead = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

            List<Goods> records = csvRead.GetRecords<Goods>().ToList();

            reader.Close();

            List<Goods> temporary = new List<Goods>();
            foreach (Goods good in records)
            {
                bool isDataExists = false;
                for (int i = 0; i < temporary.Count; i++)
                {
                    if (temporary[i].Name == good.Name && temporary[i].Recipient == good.Recipient && temporary[i].Date == good.Date)
                    {
                        temporary[i].Quantity += good.Quantity;
                        isDataExists = true;
                    }
                }

                if (!isDataExists)
                {
                    temporary.Add(good);
                }
            }
            temporary.Sort();

            return temporary;
        }
    }
}
