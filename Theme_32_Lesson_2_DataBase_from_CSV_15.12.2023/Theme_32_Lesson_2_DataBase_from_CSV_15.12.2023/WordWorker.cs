using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Theme_32_Lesson_2_DataBase_from_CSV_15._12._2023
{
    public static class WordWorker
    {
        public static void WriteToWord(List<Iris> iris)
        {
            string fileName = $"{Directory.GetCurrentDirectory()}\\Таблица.docx";
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Open($"{Directory.GetCurrentDirectory()}\\Таблица.docx");

            Word.Table table = doc.Tables[1];

            // Заполнение ячеек таблицы
            for (int i = 1; i <= iris.Count; i++)
            {
                table.Rows.Add(5);
                table.Cell(i + 1, 1).Range.Text = i.ToString();
                table.Cell(i + 1, 2).Range.Text = iris[i - 1].SepalLegth.ToString();
                table.Cell(i + 1, 3).Range.Text = iris[i - 1].SepalWidth.ToString();
                table.Cell(i + 1, 4).Range.Text = iris[i - 1].PetalLength.ToString();
                table.Cell(i + 1, 5).Range.Text = iris[i - 1].PetalWidth.ToString();
            }

            doc.SaveAs(fileName);
            doc.Close();
        }
    }
}
