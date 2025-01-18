using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;

namespace TodoList.TestFixtures.Fixtures;

public class TodoItemCategoryFixture
{
    public static Guid TodoItemCategoryId => new("902ce7b7-e85a-4ed0-a8a0-47daa722eed3");
    public static Guid TodoItemCategoryToDeleteId => new("37d95300-abe2-4f67-94b2-de979ca9cf82");

    public static TodoItemCategory TodoItemCategory => new()
    {
        Id = TodoItemCategoryId,
        Name = "Default Category",
        Description = "This is a default category for todos.",
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow.AddHours(12),
    };

    public static TodoItemCategoryViewDto TodoItemCategoryViewDto => new()
    {
        Id = TodoItemCategory.Id,
        Name = TodoItemCategory.Name,
        Description = TodoItemCategory.Description,
        CreatedAt = TodoItemCategory.CreatedAt,
        UpdatedAt = TodoItemCategory.UpdatedAt
    };

    public static TodoItemCategoryCreateDto TodoItemCategoryCreateDto => new()
    {
        Name = "New Category",
        Description = "This is a newly created category."
    };

    public static TodoItemCategoryUpdateDto TodoItemCategoryUpdateDto => new()
    {
        Name = "Updated Category",
        Description = "This category has been updated."
    };

    public static TodoItemCategory TodoItemCategoryToDelete => new()
    {
        Id = TodoItemCategoryToDeleteId,
        Name = "Category to delete",
        Description = "This is a category to be deleted",
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow.AddHours(12),
    };

    public static List<TodoItemCategory> TodoItemCategories =>
    [
        TodoItemCategory,
        TodoItemCategoryToDelete,
    ];
}
