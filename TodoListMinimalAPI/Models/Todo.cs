using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoListMinimalAPI.Data
{
    public record Todo
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = String.Empty;
        public bool Done { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
        }
    }
}