﻿
using TodoApi.Interfaces.Entities;

namespace TodoApi.Entities;

public class TodoItemCategory : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
