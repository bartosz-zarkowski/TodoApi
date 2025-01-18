using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItem;
using TodoList.IntegrationTests.Configs;
using TodoList.TestFixtures.Fixtures;

namespace TodoList.IntegrationTests.Controllers;

public class ItemControllerTest 
    : BaseCRUDControllerTest<TodoItem, TodoItemViewDto, TodoItemCreateDto, TodoItemUpdateDto>
{
    public ItemControllerTest(CustomWebApplicationFactory<Program> factory) : base(factory) { }

    [Fact]
    public async Task PutStatus_ReturnsSuccess()
    {
        Guid resourceId = Entity.Id;

        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/{resourceId}/status", StatusDto);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PutStatus_ForNotExistingTodoItem_ReturnsNotFound()
    {
        Guid notExistingResourceId = Guid.NewGuid();

        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/{notExistingResourceId}/status", StatusDto);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task PutStatus_ForInvalidBody_ReturnsBadRequest()
    {
        Guid resourceId = Entity.Id;

        var response = await HttpClient.PutAsJsonAsync($"{BaseUrl}/{resourceId}/status", string.Empty);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    protected override string BaseUrl => "/api/v1/items";

    protected override TodoItem Entity => TodoItemFixture.TodoItem;
    protected override TodoItemViewDto ViewDto => TodoItemFixture.TodoItemViewDto;
    protected override TodoItemCreateDto CreateDto => TodoItemFixture.TodoItemCreateDto;
    protected override TodoItemUpdateDto UpdateDto => TodoItemFixture.TodoItemUpdateDto;
    protected override TodoItem EntityToDelete => TodoItemFixture.TodoItemToDelete;
    protected TodoItemStatusDto StatusDto => TodoItemFixture.TodoItemStatusDto;
}
