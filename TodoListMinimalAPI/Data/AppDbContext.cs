using Microsoft.EntityFrameworkCore;

namespace TodoListMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> TodoTasks { get; set; } //um dbset da minha classe todo
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(); //conection string
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
//unico arquivo que o entity framework precisa para trabalhar