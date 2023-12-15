using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_32_Lesson_2_DataBase_from_CSV_15._12._2023
{
    public static class CSVWorker
    {

        //public static string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csv*", SearchOption.AllDirectories);

        public static List<Iris> UploadData()
        {
            List<Iris> iris = new List<Iris>();
            StreamReader reader = new StreamReader("iris.csv");

            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);

            CsvReader csvReader = new CsvReader(reader, csvConfiguration);
            
            iris = csvReader.GetRecords<Iris>().ToList();
            
            reader.Close();
            return iris;
        }
    }
}
