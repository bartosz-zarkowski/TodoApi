using TodoApi.Dtos.TodoItemCategory;
using TodoApi.Entities;

namespace ToDoList.DataFixtures;

public class TodoItemCategoryFixture
{
    public static Guid TodoItemCategoryId => new("902ce7b7-e85a-4ed0-a8a0-47daa722eed3");

    public static TodoItemCategory TodoItemCategory => new()
    {
        Id = TodoItemCategoryId,
        Name = "Default Category",
        Description = "This is a default category for todos.",
        CreatedAt = new DateTimeOffset(2025, 1, 1, 1, 0, 0, TimeSpan.Zero),
        UpdatedAt = new DateTimeOffset(2025, 2, 1, 1, 0, 0, TimeSpan.Zero)
    };

    public static TodoItemCategoryViewDto todoItemCategoryViewDto => new()
    {
        Id = TodoItemCategory.Id,
        Name = TodoItemCategory.Name,
        Description = TodoItemCategory.Description,
        CreatedAt = TodoItemCategory.CreatedAt,
        UpdatedAt = TodoItemCategory.UpdatedAt
    };

    public static TodoItemCategoryCreateDto todoItemCategoryCreateDto => new()
    {
        Name = "New Category",
        Description = "This is a newly created category."
    };

    public static TodoItemCategoryUpdateDto todoItemCategoryUpdateDto => new()
    {
        Name = "Updated Category",
        Description = "This category has been updated."
    };
}
