using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TodoListMinimalAPI.Data;
using System.Linq;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(); //gerencia toda a conexão com o banco, sempre que tive rum db context usa um addDbContext
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!"); //rota e função que vai ser chamada
app.MapGet("/all", (AppDbContext context) =>
{
    var todos = context.Todos.ToList();
    return Results.Ok(todos);
});

app.MapGet("/getbystatus/{status}", (bool status, AppDbContext context) => //nomear melhor rotas
{
    //var selectTodo = context.Todos.Find(status); // porque não funciona?
    var selectTodo = (from s in context.Todos
                      where s.Done == status
                      select s);
        
    if(selectTodo is null) return Results.NotFound();
    return Results.Ok(selectTodo);
    
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
    
    if(update is null) return Results.NotFound();
    
    update.Title = todo.Title;
    update.Done = todo.Done;
    context.SaveChanges();
    return Results.Ok(todo);
    
        
});

app.MapDelete("/del/{id}",(int id, AppDbContext context) =>
{
    var deleteTodo = context.Todos.Find(id);

    if (deleteTodo is null) return Results.NotFound();
    
    var removed = context.Todos.Remove(deleteTodo);
    context.SaveChanges();
    return Results.Ok();  
    
});

app.Run();
