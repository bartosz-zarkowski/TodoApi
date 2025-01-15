using TodoList.Api.Enums;
using TodoList.Api.Interfaces.Entities;

namespace TodoList.Api.Entities;

public class TodoItem : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TodoItemStatus Status { get; set; } = TodoItemStatus.Pending;
    public TodoItemPriority Priority { get; set; } = TodoItemPriority.Medium;

    public Guid CategoryId { get; set; }
    public TodoItemCategory Category { get; set; }

    public DateTimeOffset DueDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
