using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Lesson_1
{
    public class DataBaseContext : DbContext // Отображает таблицу в БД
    {
        //Класс контекстa наследуется от DBContext

        public DbSet<Movies> Movies => Set<Movies>(); // Таблица

        public DataBaseContext()
        {
            Database.EnsureCreated(); // Создает БД если не создана
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Настройка конфигурации
        {
            optionsBuilder.UseSqlite("Data Source=MoviesDataBase.db");
        }
    }
}
