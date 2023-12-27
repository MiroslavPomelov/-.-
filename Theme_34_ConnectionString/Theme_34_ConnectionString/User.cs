

namespace Theme_34_ConnectionString
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Password { get; set; }

        public User() { }
        
        public User(string name, int age, string password)
        {
            Name = name;
            Age = age;
            Password = password;
        }
    }
}
