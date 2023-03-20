namespace TodoListMinimalAPI.Contracts.Response;

public class TodoPutModel
{
    public string Title { get; set; } = String.Empty;
    public bool Done { get; set; }
}
