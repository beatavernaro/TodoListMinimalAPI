namespace TodoListMinimalAPI.Data
{
    public record Todo
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
        }
    }
}