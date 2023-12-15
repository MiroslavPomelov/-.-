using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace Theme_32_Lesson_2_DataBase_from_CSV_15._12._2023
{
    public class Iris
    {
        [Ignore]
        public int Id { get; set; }
        [Name("sepal.length")]
        public double SepalLegth { get; set; }
        [Name("sepal.width")]
        public double SepalWidth { get; set; }
        [Name("petal.length")]
        public double PetalLength { get; set; }
        [Name("petal.width")]
        public double PetalWidth { get; set; }
        [Name("variety")]
        public string Variety { get; set; }

        public Iris(int id, double sepalLegth, double sepalWidth, double petalLength, double petalWidth, string variety)
        {
            Id = id;
            SepalLegth = sepalLegth;
            SepalWidth = sepalWidth;
            PetalLength = petalLength;
            PetalWidth = petalWidth;
            Variety = variety;
        }

        public Iris()
        {

        }
    }
}
