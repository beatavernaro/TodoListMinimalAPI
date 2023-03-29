namespace TodoListMinimalAPI.Data
{
    public record Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }
        public string Subject { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public double Grade { get; set; }
        public DateOnly DueDate { get; set; }
//TODO - Altualizar model

        public Todo()
        {
            Id = Guid.NewGuid();
        }
    }
}