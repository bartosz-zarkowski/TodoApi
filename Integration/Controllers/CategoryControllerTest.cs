using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TodoList.Integration.Configs;
using ToDoList.DataFixtures;

namespace TodoList.Integration.Controllers;

public class CategoryControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CategoryControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        factory.InitializeAsync().Wait();
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task GetCategoriesEndpoint_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/api/v1/Category");

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GetCategoryEndpoint_ForNotExistingCategory_ReturnsNotFound()
    {
        Guid notExistingCategoryId = Guid.NewGuid();

        var response = await _client.GetAsync($"/api/v1/Category/{notExistingCategoryId}");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task PostCategoryEndpoint_ForValidTodoItemCategoryUpdateDto_ReturnsSuccess()
    {
        Guid notExistingCategoryId = Guid.NewGuid();
        string todoItemCategoryUpdateDtoString = JsonConvert.SerializeObject(TodoItemCategoryFixture.todoItemCategoryUpdateDto);

        var response = await _client.PostAsJsonAsync($"/api/v1/Category", TodoItemCategoryFixture.todoItemCategoryCreateDto);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task PutCategoryEndpoint_ForNotExistingCategory_ReturnsNotFound()
    {
        Guid notExistingCategoryId = Guid.NewGuid();
        string todoItemCategoryUpdateDtoString = JsonConvert.SerializeObject(TodoItemCategoryFixture.todoItemCategoryUpdateDto);

        var response = await _client.PutAsJsonAsync($"/api/v1/Category/{notExistingCategoryId}", TodoItemCategoryFixture.todoItemCategoryUpdateDto);

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task DeleteCategoryEndpoint_ForNotExistingCategory_ReturnsNotFound()
    {
        Guid notExistingCategoryId = Guid.NewGuid();

        var response = await _client.DeleteAsync($"/api/v1/Category/{notExistingCategoryId}");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        var content = await response.Content.ReadAsStringAsync();
        content.Should().NotBeNullOrEmpty();
    }
}
