using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.Api.Interfaces.Dtos.Common;
using TodoList.Api.Interfaces.Entities;
using TodoList.IntegrationTests.Configs;

namespace TodoList.IntegrationTests.Controllers;

public abstract class BaseCRUDControllerTest<TEntity, TViewDto, TCreateDto, TUpdateDto>
    : IClassFixture<CustomWebApplicationFactory<Program>>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{
    private readonly HttpClient _httpClient;

    protected HttpClient HttpClient => _httpClient;

    protected abstract string BaseUrl { get; }

    public BaseCRUDControllerTest(CustomWebApplicationFactory<Program> factory)
    {
        factory.InitializeAsync().Wait();
        _httpClient = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task GetAllResources_ReturnsSuccess()
    {
        var response = await _httpClient.GetAsync(BaseUrl);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetResourceById_ReturnsSuccess()
    {
        Guid resourceId = Entity.Id;

        var response = await _httpClient.GetAsync($"{BaseUrl}/{resourceId}");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetResourceById_ForNotExistingResource_ReturnsNotFound()
    {
        Guid notExistingResourceId = Guid.NewGuid();

        var response = await _httpClient.GetAsync($"{BaseUrl}/{notExistingResourceId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task PostResource_ReturnsSuccess()
    {
        var response = await _httpClient.PostAsJsonAsync(BaseUrl, CreateDto);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PostResource_ForInvalidBody_ReturnsBadRequest()
    {
        var response = await _httpClient.PostAsJsonAsync(BaseUrl, string.Empty);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PutResource_ReturnsSuccess()
    {
        Guid resourceId = Entity.Id;

        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{resourceId}", UpdateDto);

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task PutResource_ForInvalidBody_ReturnsBadRequest()
    {
        Guid resourceId = Entity.Id;

        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{resourceId}", string.Empty);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest); ;
    }

    [Fact]
    public async Task PutResource_ForNotExistingResource_ReturnsNotFound()
    {
        Guid notExistingResourceId = Guid.NewGuid();

        var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{notExistingResourceId}", UpdateDto);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task DeleteResource_ReturnsSuccess()
    {
        Guid resourceId = EntityToDelete.Id;

        var response = await _httpClient.DeleteAsync($"{BaseUrl}/{resourceId}");

        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task DeleteResource_ForNotExistingResource_ReturnsNotFound()
    {
        Guid notExistingResourceId = Guid.NewGuid();

        var response = await _httpClient.DeleteAsync($"{BaseUrl}/{notExistingResourceId}");

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    protected abstract TEntity Entity { get; }
    protected abstract TViewDto ViewDto { get; }
    protected abstract TCreateDto CreateDto { get; }
    protected abstract TUpdateDto UpdateDto { get; }
    protected abstract TEntity EntityToDelete { get; }
}
