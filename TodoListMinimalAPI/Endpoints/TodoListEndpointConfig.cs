using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Endpoints
{
    public class TodoListEndpointConfig
    {
        public static void AddEndpoint(WebApplication app)
        {
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

                if (selectTodo is null) return Results.NotFound();
                return Results.Ok(selectTodo);

            });

            app.MapPost("/post", (AppDbContext context, Todo todo) =>
            {
                todo.Id = Guid.NewGuid();
                context.Todos.Add(todo);
                context.SaveChanges();
                return Results.Created($"/post/{todo.Id}", todo);
            });

            app.MapPut("/put/{id}", (AppDbContext context, Todo todo, Guid id) =>
            {
                var update = context.Todos.Find(id);

                if (update is null) return Results.NotFound();

                update.Id = id;
                update.Title = todo.Title;
                update.Done = todo.Done;
                context.SaveChanges();
                return Results.Ok(update);


            });

            app.MapDelete("/del/{id}", (Guid id, AppDbContext context) =>
            {
                var deleteTodo = context.Todos.Find(id);

                if (deleteTodo is null) return Results.NotFound();

                var removed = context.Todos.Remove(deleteTodo);
                context.SaveChanges();
                return Results.Ok();

            });
        }
    }
}
