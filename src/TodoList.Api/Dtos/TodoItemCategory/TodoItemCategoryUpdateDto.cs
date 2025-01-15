using TodoList.Api.Interfaces.Dtos.Common;

namespace TodoList.Api.Dtos.TodoItemCategory;

public class TodoItemCategoryUpdateDto : IDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}