using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Theme_34_ConnectionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> list = new List<User>()
            {
                new User("Miroslav", 24, "asdasd"),
                new User("Vasya", 27, "123123"),
                new User("Nikolay", 44, "3e3e32r"),
            };

            using (DatabaseContext dBContext = new DatabaseContext())
            {
                dBContext.Users.AddRange(list);
                dBContext.SaveChanges();
            }











            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("myDatabaseConfigurations.json");
            //var config = builder.Build();
            //var connectionString = config.GetConnectionString("DefaultConnection");

            //var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            //var vers = new MySqlServerVersion(new Version(8, 0, 25));
            //var options = optionsBuilder.UseMySql(connectionString, vers).Options;

            //using (DatabaseContext db = new DatabaseContext(options))
            //{

            //}







            //var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            //var mysqlVers = new MySqlServerVersion(new Version(8, 0, 25));

            //var options = optionBuilder.UseMySql("", mysqlVers).Options;

            //using (DatabaseContext db = new DatabaseContext(options))
            //{

            //}





            //using (DatabaseContext dBContext = new DatabaseContext("192.168.10.170", "remote_database", "cifra-student-remote", "Cifra39"))
            //{
            //    //foreach (var user in list)
            //    //{
            //        dBContext.Users.AddRange(list);
            //    //}
            //    dBContext.SaveChanges();
            //}
        }
    }
}