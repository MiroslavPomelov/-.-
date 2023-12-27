using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_34_ConnectionString
{
    public class DatabaseContext : DbContext
    {
        private string _databaseConnectionString;
        public DbSet<User> Users { get; set; } = null!;

        public DatabaseContext(string ip, string database, string userName, string userPass)
        {
            _databaseConnectionString = $"server={ip};database={database};user={userName};password={userPass};";
            Console.WriteLine(_databaseConnectionString);

            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var vers = new Version(8, 0, 25);
            var mySqlVers = new MySqlServerVersion(vers);
            optionsBuilder.UseMySql(_databaseConnectionString, mySqlVers);
        }
    }
}
