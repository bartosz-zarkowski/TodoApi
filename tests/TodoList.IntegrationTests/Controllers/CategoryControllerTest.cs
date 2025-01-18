using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;
using TodoList.IntegrationTests.Configs;
using TodoList.TestFixtures.Fixtures;

namespace TodoList.IntegrationTests.Controllers;

public class CategoryControllerTest
    : BaseCRUDControllerTest<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto>
{
    public CategoryControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory) { }

    protected override string BaseUrl => "/api/v1/categories";

    protected override TodoItemCategory Entity => TodoItemCategoryFixture.TodoItemCategory;

    protected override TodoItemCategoryViewDto ViewDto => TodoItemCategoryFixture.TodoItemCategoryViewDto;

    protected override TodoItemCategoryCreateDto CreateDto => TodoItemCategoryFixture.TodoItemCategoryCreateDto;

    protected override TodoItemCategoryUpdateDto UpdateDto => TodoItemCategoryFixture.TodoItemCategoryUpdateDto;

    protected override TodoItemCategory EntityToDelete => TodoItemCategoryFixture.TodoItemCategoryToDelete;
}
