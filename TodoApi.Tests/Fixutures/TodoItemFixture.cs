using TodoApi.Dtos.TodoItem;
using TodoApi.Entities;
using TodoApi.Enums;

namespace TodoApi.Tests.DummyData;

public static class TodoItemFixture
{
    public static Guid TodoItemId => new("9f82826f-6bc0-4dde-8eb7-ea1160f7b667");

    public static TodoItem TodoItem => new()
    {
        Id = TodoItemId,
        Title = "Sample Todo Item",
        Description = "This is a sample todo item description.",
        Status = TodoItemStatus.InProgress,
        Priority = TodoItemPriority.High,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = new DateTimeOffset(2025, 3, 1, 10, 0, 0, TimeSpan.Zero),
        CreatedAt = new DateTimeOffset(2025, 1, 1, 11, 0, 0, TimeSpan.Zero),
        UpdatedAt = new DateTimeOffset(2025, 2, 1, 12, 0, 0, TimeSpan.Zero)
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
        DueDate = new DateTimeOffset(2025, 1, 15, 12, 0, 0, TimeSpan.Zero)
    };

    public static TodoItemUpdateDto TodoItemUpdateDto => new()
    {
        Title = "Updated Todo Item",
        Description = "This is an updated todo item.",
        Priority = TodoItemPriority.Critical,
        CategoryId = TodoItemCategoryFixture.TodoItemCategoryId,
        DueDate = new DateTimeOffset(2025, 1, 16, 12, 0, 0, TimeSpan.Zero)
    };

    public static TodoItemStatusDto TodoItemStatusDto => new()
    {
        Status = TodoItemStatus.Completed
    };
}
