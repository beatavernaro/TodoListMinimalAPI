using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TodoListMinimalAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskModel> TodoTasks { get; set; } //um dbset da minha classe todo
    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    => options.UseSqlite(); //conection string
    //substituiu pela variavel de ambiente
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}


//unico arquivo que o entity framework precisa para trabalhar