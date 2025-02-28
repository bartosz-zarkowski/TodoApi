﻿using TodoList.Api.Enums;
using TodoList.Api.Interfaces.Dtos.Common;

namespace TodoList.Api.Dtos.TodoItem;

public class TodoItemViewDto : IViewDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TodoItemStatus Status { get; set; }
    public TodoItemPriority Priority { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
