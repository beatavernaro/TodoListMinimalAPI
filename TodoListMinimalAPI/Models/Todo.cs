namespace TodoListMinimalAPI.Data
{
    public record Todo
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }
    }
}