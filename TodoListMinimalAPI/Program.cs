using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TodoListMinimalAPI.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(); //gerencia todfa a conexão com o banco, sempre que tive rum db context usa um addDbContext
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!"); //rota e função que vai ser chamada
app.MapGet("/all", (AppDbContext context) =>
{
    var todos = context.Todos.ToList();
    return Results.Ok(todos);
});

app.MapGet("/getbystatus/{status}", (bool status, AppDbContext context) =>
{
    var selectTodo = context.Todos.Find(status);
    if(selectTodo is not null)
    {
        return Results.Ok(selectTodo);
    }
    return Results.NotFound();
});

app.MapPost("/post", (AppDbContext context, Todo todo) => 
{
    context.Todos.Add(todo);
    context.SaveChanges();
    return Results.Created($"/post/{todo.Id}", todo);
});

app.MapPut("/put/{id}", (AppDbContext context, Todo todo, int id) =>
{
    var update = context.Todos.Find(id);
    
    if(update is not null){
        update.Title = todo.Title;
        update.Done = todo.Done;
        context.SaveChanges();
        return Results.Ok(todo);
    }
        return Results.NotFound();
});

app.MapDelete("/del/{id}",(int id, AppDbContext context) =>
{
    var deleteTodo = context.Todos.Find(id);

    if (deleteTodo is not null)
    {
        var removed = context.Todos.Remove(deleteTodo);
        context.SaveChanges();
        return Results.Ok();
    }
    return Results.BadRequest();
    
});

app.Run();
