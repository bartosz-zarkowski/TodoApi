﻿
namespace TodoApi.Entities;

public class ToDoItemCategory : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
