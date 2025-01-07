﻿using TodoApi.Interfaces.Dtos;

namespace TodoApi.Dtos.TodoItemCategory;

public class TodoItemCategoryViewDto : IViewDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
