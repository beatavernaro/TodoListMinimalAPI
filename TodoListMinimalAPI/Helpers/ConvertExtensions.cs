using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Helpers
{
    public static class ConvertExtensions
    {
        public static TaskModel ConvertToTask(this TaskPostModel taskModel)
        {
            TaskModel response = new TaskModel();
            response.Title = taskModel.Title;
            response.Done = taskModel.Done;
            response.Subject = taskModel.Subject;
            response.Description = taskModel.Description;
            response.Grade = taskModel.Grade;
            response.DueDate = taskModel.DueDate;
            response.Id = Guid.NewGuid();

            return response;
        }
    }
}