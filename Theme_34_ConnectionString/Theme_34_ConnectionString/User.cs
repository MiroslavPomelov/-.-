

namespace Theme_34_ConnectionString
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public User() { }
        
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
