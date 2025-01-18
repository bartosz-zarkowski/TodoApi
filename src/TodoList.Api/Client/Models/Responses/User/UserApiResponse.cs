using TodoList.Api.Client.Models.Responses.User;

namespace TodoList.Api.Client.Models.Response.User;

public class UserApiResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }

    public AddressApiResponse Address { get; set; }

    public string Phone { get; set; }

    public string Website { get; set; }

    public CompanyApiResponse Company { get; set; }
}
