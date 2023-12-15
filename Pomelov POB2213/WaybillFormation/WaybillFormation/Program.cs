using CsvHelper.Configuration.Attributes;
namespace WaybillFormation
{
    class Program
    {
        private static string _dataPath = "data.csv";
        public static void Main(string[] args)
        {
            List<Goods> data = DataReader.GetDataFromCSV(_dataPath);

            TableOperator.CreateTable(data, "dataTable.xlsx");

            WaybillCreator.GetData("dataTable.xlsx");

        }
    }

    public class Goods : IComparable<Goods>
    {
        [Name("Название товара")]
        public string? Name { get; set; }
        [Name("Количество")]
        public int Quantity { get; set; }
        [Name("Стоимость")]
        public int Price { get; set; }
        [Name("ФИО поставщика")]
        public string? Provider { get; set; }
        [Name("ФИО получателя")]
        public string? Recipient { get; set; }
        [Name("Дата поставки")]
        public DateTime Date { get; set; }

        public Goods() { }

        public Goods(string name, int quantity, int price, string provider, string recipient, DateTime date)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            Provider = provider;
            Recipient = recipient;
            Date = date;
        }

        public int CompareTo(Goods? obj)
        {
            return Date.CompareTo(obj?.Date);
        }
    }
}