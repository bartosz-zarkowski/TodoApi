using Newtonsoft.Json;
using TodoList.Api.Client.Models.Response.User;

namespace TodoList.Api.Client.Repositories;

public class UserApiRepository : IUserApiRepository
{
    public const string resource = "users";

    private readonly HttpClient _httpClient;

    public UserApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("httpClient"); ;
    }

    public async Task<ICollection<UserApiResponse>> GetUsersAsync()
    {
        var response = await _httpClient.GetAsync(resource);
        response.EnsureSuccessStatusCode();

        var content = (await response.Content.ReadAsStringAsync())
            ?? throw new Exception("Response content is missing");

        return JsonConvert.DeserializeObject<ICollection<UserApiResponse>>(content);
    }
}
