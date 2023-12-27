using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;

namespace Theme_34_Prakt27._12._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var servVers = new MySqlServerVersion(new Version(8, 0, 25));
            //optionsBuilder.UseMySql("server=192.168.10.170;database=VideoGame;user=video-game-admin;password=Cifra39", servVers);
            //optionsBuilder.LogTo(_logWriter.WriteLine, LogLevel.Debug);


            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("connectionStringJson.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<VideoGameDatabseContext>();
            var vers = new MySqlServerVersion(new Version(8, 0, 25));
            var options = optionsBuilder.UseMySql(connectionString, vers).Options;


            using (VideoGameDatabseContext db = new VideoGameDatabseContext())
            {
                using (StreamWriter logWriter = new StreamWriter("alllogs.log", true))
                {
                    optionsBuilder.LogTo(logWriter.WriteLine, LogLevel.Debug);
                };
            }
        }
    }
}