using TodoListMinimalAPI.Data;

namespace TodoListMinimalAPI.Contracts.Response
{
    public class TodoPostModel
    {
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }
        //recebo um model e transformo ele num todo. retorno o todo certo com id ja
    }
}
 