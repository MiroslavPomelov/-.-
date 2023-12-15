

namespace Theme_32_Lesson_2_DataBase_from_CSV_15._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iris = CSVWorker.UploadData();

            foreach (var s in iris)
            {
                Console.WriteLine($"{s.PetalLength} {s.PetalLength} {s.PetalLength} {s.SepalWidth} {s.Variety}");
            }

            // ЗАПИСЬ В БД
            using (DataBaseContext context = new DataBaseContext())
            {
                foreach (var s in iris)
                {
                    context.Irises.Add(s);
                    context.SaveChanges();
                }
            }
            WordWorker.WriteToWord(iris);
        }
    }
}