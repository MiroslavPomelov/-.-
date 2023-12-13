using OfficeOpenXml;


namespace Entity_Framework_Lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ЗАПИСЬ В БД
            //using (DataBaseContext context = new DataBaseContext())
            //{
            //    var studentOne = new Person("Miroslav", "Pomelov", 24);
            //    var studentTwo = new Person("Dmitry", "Petrov", 32);
            //    var studentThree = new Person("Nikolay", "Sidorov", 40);

            //    context.Persons.Add(studentOne);
            //    context.Persons.Add(studentTwo);
            //    context.Persons.Add(studentThree);

            //    context.SaveChanges();
            //}

            //Console.WriteLine("Данные успешно длбавлены в БД");




            // ПОЛУЧЕНИЕ ДАННЫХ ИЗ БД
            using (DataBaseContext context = new DataBaseContext())
            {
                var persons = context.Movies.ToList();

                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name} - {person.Year} - {person.Director} - {person.Genre} - {person.Graduation}");
                }

                ExcelPackage newBook = new ExcelPackage("Movies.xlsx");
                ExcelWorksheet currentSheet = newBook.Workbook.Worksheets["Movies"];

                currentSheet = newBook.Workbook.Worksheets.Add("Movies");

                currentSheet.Columns.Width = 20;

                int row = 1;
                foreach (var item in persons)
                {
                    currentSheet.Cells[row, 1].Value = item.Name;
                    currentSheet.Cells[row, 2].Value = item.Year;
                    currentSheet.Cells[row, 3].Value = item.Director;
                    currentSheet.Cells[row, 4].Value = item.Genre;
                    currentSheet.Cells[row, 5].Value = item.Graduation;
                    row++;
                }
                newBook.Save();
            }

        }
    }
}