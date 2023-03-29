using Microsoft.EntityFrameworkCore;

namespace TodoListMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> TodoTasks { get; set; } //um dbset da minha classe todo
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared"); //conection string
    }
}
//unico arquivo que o entity framework precisa para trabalhar