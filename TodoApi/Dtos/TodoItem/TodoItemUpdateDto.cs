﻿using TodoApi.Enums;
using TodoApi.Interfaces.Dtos;

namespace TodoApi.Dtos.TodoItem;

public class TodoItemUpdateDto : IDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TodoItemStatus? Status { get; set; }
    public TodoItemPriority? Priority { get; set; }
    public Guid? CategoryId { get; set; }
    public DateTimeOffset? DueDate { get; set; }
}