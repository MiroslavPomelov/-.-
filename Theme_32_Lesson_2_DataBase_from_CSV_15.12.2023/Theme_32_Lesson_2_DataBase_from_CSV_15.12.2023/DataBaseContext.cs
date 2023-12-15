using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_32_Lesson_2_DataBase_from_CSV_15._12._2023
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Iris> Irises => Set<Iris>();

        public DataBaseContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=Iris.db");
        }
    }
}
