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
            response.Id = Guid.NewGuid();
            return response;
        }
    }
}
