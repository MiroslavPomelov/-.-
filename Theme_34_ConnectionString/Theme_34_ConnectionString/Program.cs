namespace Theme_34_ConnectionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> list = new List<User>()
           {
               new User("Miroslav", 24),
               new User("Vasya", 27),
               new User("Nikolay", 44),
           };

            using (DatabaseContext dBContext = new DatabaseContext("192.168.10.170", "remote_database", "cifra-student-remote", "Cifra39"))
            {
                //foreach (var user in list)
                //{
                    dBContext.Users.AddRange(list);
                //}
                dBContext.SaveChanges();
            }
        }
    }
}