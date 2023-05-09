using TodoListMinimalAPI.Models;

namespace TodoListMinimalAPI.Data;

public record TaskModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool Done { get; set; }
    public SubjectEnum Subject { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Grade { get; set; }
    public DateOnly DueDate { get; set; }

    public TaskModel()
    {
        Id = Guid.NewGuid();
    }
}