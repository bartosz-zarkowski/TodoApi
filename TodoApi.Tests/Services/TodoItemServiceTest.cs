
using FluentAssertions;
using Moq;
using TodoApi.Dtos.TodoItem;
using TodoApi.Entities;
using TodoApi.Interfaces.Repositories;
using TodoApi.Services;
using ToDoList.DataFixtures.Fixtures;

namespace TodoList.Unit.Services;

public class TodoItemServiceTest
    : BaseEntityServiceTest<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto, TodoItemService, IEntityRepository<TodoItem>>
{
    [Fact]
    public async Task UpdateStatusById_ForNotExisitngItem_ReturnsNull()
    {
        Guid todoItemId = Entity.Id;
        TodoItemStatusDto statusDto = StatusDto;

        _repositoryMock.Setup(r => r.FindByIdAsync(todoItemId))
            .ReturnsAsync(null as TodoItem);

        TodoItemViewDto? viewDtoResult = await _service.UpdateStatusByIdAsync(todoItemId, statusDto);

        viewDtoResult.Should().BeNull();
        _repositoryMock.Verify(r => r.FindByIdAsync(todoItemId), Times.Once);
    }

    [Fact]
    public async Task UpdateStatusById_ForExistingItem_ReturnsItemViewDto()
    {
        var todoItemId = Entity.Id;
        var todoItemStatusDto = StatusDto;
        var todoItem = Entity;
        var todoItemViewDto = ViewDto;

        _repositoryMock.Setup(r => r.FindByIdAsync(todoItemId))
            .ReturnsAsync(todoItem);
        _mapperMock.Setup(m => m.Map(todoItemStatusDto, todoItem))
            .Callback(() => todoItem.Status = todoItemStatusDto.Status);
        _mapperMock.Setup(m => m.Map<TodoItemViewDto>(todoItem))
            .Returns(todoItemViewDto);

        var result = await _service.UpdateStatusByIdAsync(todoItemId, todoItemStatusDto);

        result.Should().BeEquivalentTo(todoItemViewDto);
        _repositoryMock.Verify(r => r.FindByIdAsync(todoItemId), Times.Once);
        _mapperMock.Verify(m => m.Map(todoItemStatusDto, todoItem), Times.Once);
        _repositoryMock.Verify(r => r.SaveAsync(), Times.Once);
        _mapperMock.Verify(m => m.Map<TodoItemViewDto>(todoItem), Times.Once);
    }

    protected override TodoItemService CreateService() =>
    new TodoItemService(_repositoryMock.Object, _mapperMock.Object, _validatorMock.Object);

    protected override TodoItem Entity => TodoItemFixture.TodoItem;
    protected override TodoItemViewDto ViewDto => TodoItemFixture.TodoItemViewDto;
    protected override TodoItemCreateDto CreateDto => TodoItemFixture.TodoItemCreateDto;
    protected override TodoItemUpdateDto UpdateDto => TodoItemFixture.TodoItemUpdateDto;
    protected TodoItemStatusDto StatusDto => TodoItemFixture.TodoItemStatusDto;
}
