using TodoListMinimalAPI.Contracts.Response;
using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Helpers
{
    public static class ConverterExtensions
    {
        public static Todo ConvertToTodo(this TodoPostModel todoModel)
        {
            Todo response = new Todo();
            response.Title = todoModel.Title;
            response.Done = todoModel.Done;
            response.Subject = todoModel.Subject;
            response.Description = todoModel.Description;
            response.Grade = todoModel.Grade;
            response.DueDate = todoModel.DueDate;
            response.Id = Guid.NewGuid();
            return response;
        }
    }
}