using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItem;
using TodoList.Api.Enums;

namespace TodoList.TestFixtures.Fixtures;

public static class TodoItemFixture
{
    public static Guid TodoItemId => new("9f82826f-6bc0-4dde-8eb7-ea1160f7b667");
    public static Guid TodoItemToDeleteId => new("7c2be6e7-d35c-4f72-b8b2-452bb4cea592");

    public static TodoItem TodoItem => new()
    {
        Id = TodoItemId,
        Title = "Sample Todo Item",
        Description = "This is a sample todo item description.",
        Status = TodoItemStatus.InProgress,
        Priority = TodoItemPriority.High,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = DateTimeOffset.UtcNow.AddDays(1),
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow.AddHours(12),
    };

    public static TodoItemViewDto TodoItemViewDto => new()
    {
        Id = TodoItemId,
        Title = TodoItem.Title,
        Description = TodoItem.Description,
        Status = TodoItem.Status,
        Priority = TodoItem.Priority,
        CategoryId = TodoItem.CategoryId,
        CategoryName = TodoItemCategoryFixture.TodoItemCategory.Name,
        DueDate = TodoItem.DueDate,
        CreatedAt = TodoItem.CreatedAt,
        UpdatedAt = TodoItem.UpdatedAt,
    };

    public static TodoItemCreateDto TodoItemCreateDto => new()
    {
        Title = "New Todo Item",
        Description = "This is a new todo item.",
        Priority = TodoItemPriority.High,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = DateTimeOffset.UtcNow.AddDays(2),
    };

    public static TodoItemUpdateDto TodoItemUpdateDto => new()
    {
        Title = "Updated Todo Item",
        Description = "This is an updated todo item.",
        Priority = TodoItemPriority.Critical,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = DateTimeOffset.UtcNow.AddDays(3),
    };

    public static TodoItem TodoItemToDelete => new()
    {
        Id = TodoItemToDeleteId,
        Title = "Todo Item To Delete",
        Description = "This is a sample todo item to delete description.",
        Status = TodoItemStatus.Pending,
        Priority = TodoItemPriority.Low,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = DateTimeOffset.UtcNow.AddDays(1),
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow.AddHours(12),
    };

    public static TodoItemStatusDto TodoItemStatusDto => new()
    {
        Status = TodoItemStatus.Completed
    };

    public static List<TodoItem> TodoItems =>
    [
        TodoItem,
        TodoItemToDelete
    ];
}
