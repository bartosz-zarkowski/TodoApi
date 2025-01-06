
using TodoApi.Enums;

namespace TodoApi.Entities;

public class TodoItem : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public TodoItemStatus Status { get; set; } = TodoItemStatus.Pending;
    public TodoItemPriority Priority { get; set; } = TodoItemPriority.Medium;

    public Guid CategoryId { get; set; }
    public required ToDoItemCategory Category { get; set; }

    public DateTimeOffset DueDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
