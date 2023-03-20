using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Contracts.Response
{
    public class TodoPostModel
    {
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }

        public static Todo Converte(TodoPostModel todoModel)
        {
            Todo response = new Todo();
            response.Title = todoModel.Title;
            response.Done = todoModel.Done;
            response.Id = Guid.NewGuid();
            return response;
        }
        //recebo um model e transformo ele num todo. retorno o todo certo com id ja
    }
}
 