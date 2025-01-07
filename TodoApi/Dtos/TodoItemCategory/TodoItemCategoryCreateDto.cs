using TodoApi.Interfaces.Dtos;

namespace TodoApi.Dtos.TodoItemCategory;

public class TodoItemCategoryCreateDto : IDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}