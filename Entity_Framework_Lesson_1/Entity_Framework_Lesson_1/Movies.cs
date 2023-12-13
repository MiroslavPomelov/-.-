using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Lesson_1
{
    public class Movies
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public double Graduation { get; set; }

        public Movies(string name, int year, string director, string genre, double graduation)
        {
            Name = name;
            Year = year;
            Director = director;
            Genre = genre;
            Graduation = graduation;
        }
    }
}
