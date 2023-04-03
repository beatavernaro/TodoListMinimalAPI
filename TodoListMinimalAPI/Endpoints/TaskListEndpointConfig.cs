using FluentValidation;
using System.ComponentModel.DataAnnotations;
using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Helpers;
using TodoListMinimalAPI.Validators;

namespace TodoListMinimalAPI.Endpoints
{
    public class TaskListEndpointConfig
    {
        TaskValidator validator = new TaskValidator();
        public static void AddEndpoint(WebApplication app)
        {
            #region GET
            app.MapGet("/api/tasks", (AppDbContext context) =>
            {
                var orderTasks = (from task in context.TodoTasks
                                  orderby task.DueDate
                                  select task).ToList();

                if (orderTasks.Count == 0) return Results.NotFound("No tasks found");

                return Results.Ok(orderTasks);
            });

            app.MapGet("/api/tasks/{status}", (bool status, AppDbContext context) =>
            {
                var selectByStatus = (from task in context.TodoTasks
                                      where task.Done == status
                                      select task).ToList();

                if (selectByStatus.Count == 0) return Results.NotFound($"No results with the status {status}");

                return Results.Ok(selectByStatus);
            });

            app.MapGet("/api/tasks/overdueTasks", (AppDbContext context) =>
             {
                 DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                 var selectOverdueTasks = (from tasks in context.TodoTasks
                                   where tasks.DueDate < today
                                   select tasks).ToList();

                 if (selectOverdueTasks.Count == 0) return Results.Ok("There is no overdue task for today");

                 return Results.Ok(selectOverdueTasks);
             });

            #endregion

            #region POST
            app.MapPost("/api", (AppDbContext context, TaskPostModel taskPostModel) =>
            {
                //TODO - fazer validação da entidade com fluent validation
                var response = taskPostModel.ConvertToTask();

                var validationResults = TaskValidator.Valid(response);
                if (validationResults.Count() != 0)
                    return Results.BadRequest($"{validationResults[0]}");

                context.TodoTasks.Add(response);
                context.SaveChanges();
                return Results.Created($"/{response.Id}", taskPostModel);
            });
            #endregion

            #region PUT
            app.MapPut("/api/{id}", (AppDbContext context, TaskPutModel taskModel, Guid id) =>
            {
                //TODO - fazer validação da entidade com fluent validation
                var taskToUpdate = context.TodoTasks.Find(id);

                if (taskToUpdate is null) return Results.NotFound("No matches found with the given ID");
                
                taskToUpdate.Done = taskModel.Done;
                taskToUpdate.Grade = taskModel.Grade;

                var validationResults = TaskValidator.Valid(taskToUpdate);
                if (validationResults.Count() != 0)
                    return Results.BadRequest($"{validationResults[0]}");

                context.SaveChanges();

                return Results.Ok(taskToUpdate);

            });
            #endregion

            #region DELETE
            app.MapDelete("/api/{id}", (Guid id, AppDbContext context) =>
            {
                var deleteTask = context.TodoTasks.Find(id);

                if (deleteTask is null) return Results.NotFound();

                var removed = context.TodoTasks.Remove(deleteTask);
                context.SaveChanges();

                return Results.Ok("Deleted!");
            });
            #endregion
        }

    }
}
