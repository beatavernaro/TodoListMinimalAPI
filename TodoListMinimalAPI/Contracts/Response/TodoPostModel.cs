namespace TodoListMinimalAPI.Contracts.Response
{
    public class TodoPostModel
    {
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }
        public string Subject { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Grade { get; set; }
        public DateOnly DueDate { get; set; }

        //recebo um model e transformo ele num todo. retorno o todo certo com id ja
    }
}
