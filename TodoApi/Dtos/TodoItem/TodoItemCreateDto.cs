using TodoApi.Enums;
using TodoApi.Interfaces.Dtos.Common;

namespace TodoApi.Dtos.TodoItem;

public class TodoItemCreateDto : IDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TodoItemPriority Priority { get; set; } = TodoItemPriority.Medium;
    public Guid CategoryId { get; set; }
    public DateTimeOffset DueDate { get; set; }
}