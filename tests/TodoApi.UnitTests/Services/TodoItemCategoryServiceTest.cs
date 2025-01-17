using FluentAssertions;
using Moq;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Services;
using TodoList.TestFixtures.Fixtures;

namespace TodoList.UnitTests.Services;

public class TodoItemCategoryServiceTest
    : BaseEntityServiceTest<TodoItemCategory, TodoItemCategoryViewDto, TodoItemCategoryCreateDto, TodoItemCategoryUpdateDto, TodoItemCategoryService, ITodoItemCategoryRepository>
{
    [Fact]
    public async Task IsExistingCategoryAsync_ForExisitngCategory_ReturnsTrue()
    {
        var categoryId = Entity.Id;

        _repositoryMock.Setup(r => r.IsExisiingCategoryAsync(categoryId))
            .ReturnsAsync(true);

        bool isExistingCategoryResponse = await _service.IsExistingCategoryAsync(categoryId);

        isExistingCategoryResponse.Should().BeTrue();
        _repositoryMock.Verify(r => r.IsExisiingCategoryAsync(categoryId), Times.Once);
    }

    [Fact]
    public async Task IsExistingCategoryAsync_ForNotExisitngCategory_ReturnsFalse()
    {
        var categoryId = Entity.Id;

        _repositoryMock.Setup(r => r.IsExisiingCategoryAsync(categoryId))
            .ReturnsAsync(false);

        bool isExistingCategoryResponse = await _service.IsExistingCategoryAsync(categoryId);

        isExistingCategoryResponse.Should().BeFalse();
        _repositoryMock.Verify(r => r.IsExisiingCategoryAsync(categoryId), Times.Once);
    }

    protected override TodoItemCategoryService CreateService() =>
        new TodoItemCategoryService(_repositoryMock.Object, _mapperMock.Object, _validatorMock.Object);

    protected override TodoItemCategory Entity => TodoItemCategoryFixture.TodoItemCategory;
    protected override TodoItemCategoryViewDto ViewDto => TodoItemCategoryFixture.todoItemCategoryViewDto;
    protected override TodoItemCategoryCreateDto CreateDto => TodoItemCategoryFixture.todoItemCategoryCreateDto;
    protected override TodoItemCategoryUpdateDto UpdateDto => TodoItemCategoryFixture.todoItemCategoryUpdateDto;
}
