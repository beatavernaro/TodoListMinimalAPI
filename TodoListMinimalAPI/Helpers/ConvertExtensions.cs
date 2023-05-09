using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;
using TodoListMinimalAPI.Models;

namespace TodoListMinimalAPI.Helpers;

public static class ConvertExtensions
{
    public static TaskModel ConvertToTask(this TaskPostModel taskModel)
    {
        TaskModel response = new()
        {
            Title = taskModel.Title,
            Done = taskModel.Done,
            Subject = taskModel.Subject,
            Description = taskModel.Description,
            Grade = taskModel.Grade,
            DueDate = taskModel.DueDate,
            Id = Guid.NewGuid()
        };

        return response;
    }
}