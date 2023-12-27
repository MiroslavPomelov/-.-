using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theme_34_Prakt27._12._2023
{
    public class VideoGameDatabseContext : DbContext
    {


        private StreamWriter _logWriter = new StreamWriter("alllogs.log", true);
        //public DbSet<User> Users { get; set; } = null!;

        public VideoGameDatabseContext((DbContextOptions<VideoGameDatabseContext> options) : base(options))
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var servVers = new MySqlServerVersion(new Version(8, 0, 25));
        //    optionsBuilder.UseMySql("server=192.168.10.170;database=remote_database;user=cifra-student-remote;password=Cifra39", servVers);
        //    optionsBuilder.LogTo(_logWriter.WriteLine, LogLevel.Debug);
        //}

        //public override void Dispose()
        //{
        //    base.Dispose();
        //    _logWriter.Dispose();
        //}
    }
}
