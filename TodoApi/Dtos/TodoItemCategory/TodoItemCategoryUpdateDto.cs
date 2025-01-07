using TodoApi.Interfaces.Dtos;

namespace TodoApi.Dtos.TodoItemCategory;

public class TodoItemCategoryUpdateDto : IDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}