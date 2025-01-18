using TodoList.Api.Client.Models.Response.User;

namespace TodoList.Api.Client.Repositories;

public interface IUserApiRepository
{
    Task<ICollection<UserApiResponse>> GetUsersAsync();
}
