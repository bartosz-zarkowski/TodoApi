using TodoApi.Interfaces.Dtos.Common;

namespace TodoApi.Dtos.TodoItemCategory;

public class TodoItemCategoryCreateDto : IDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
}