using TodoList.Api.Interfaces.Dtos.Common;

namespace TodoList.Api.Dtos.TodoItemCategory;

public class TodoItemCategoryCreateDto : IDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
}