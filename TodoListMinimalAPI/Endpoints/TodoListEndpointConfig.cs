﻿using AutoMapper;
using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Helpers;

namespace TodoListMinimalAPI.Endpoints
{
    public class TodoListEndpointConfig
    {
        public static void AddEndpoint(WebApplication app)
        {
            #region GET
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
            #endregion

            #region POST
            app.MapPost("/post", (AppDbContext context, TodoPostModel todoModel) =>
            {
                //TODO - fazer validação da entidade com fluent validation
                var response = todoModel.ConvertToTodo(); // TodoPostModel.Converte(todoModel);
                context.Todos.Add(response);
                // todo.Id = Guid.NewGuid();
                //context.Todos.Add(todo);
                context.SaveChanges();

                return Results.Created($"/{response.Id}", todoModel);
            });
            #endregion

            #region PUT
            app.MapPut("/put/{id}", (AppDbContext context, TodoPutModel todo, Guid id) =>
            {
                //TODO - fazer validação da entidade com fluent validation
                var update = context.Todos.Find(id);

                if (update is null) return Results.NotFound();

                update.Title = todo.Title;
                update.Done = todo.Done;
                context.SaveChanges();
                return Results.Ok(update);

            });
            #endregion

            #region DELETE
            app.MapDelete("/del/{id}", (Guid id, AppDbContext context) =>
            {
                var deleteTodo = context.Todos.Find(id);

                if (deleteTodo is null) return Results.NotFound();

                var removed = context.Todos.Remove(deleteTodo);
                context.SaveChanges();
                return Results.Ok();

            });
            #endregion
        }

        /*public static IMapper AutoM()
        {
            var configAutomapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Todo, TodoPostModel>();
            });
            IMapper mapper = configAutomapper.CreateMapper();
            return mapper;
        }*/
    }
}
