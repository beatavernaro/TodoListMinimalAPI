using TodoListMinimalAPI.Models;

namespace TodoListMinimalAPI.Contracts.Response;

public class TaskPostModel
{
    public string Title { get; set; } = string.Empty;
    public SubjectEnum Subject { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; }
    public DateOnly DueDate { get; set; }
    public double Grade { get; set; }

    //recebo um model e transformo ele num todo. retorno o todo certo com id ja
}
