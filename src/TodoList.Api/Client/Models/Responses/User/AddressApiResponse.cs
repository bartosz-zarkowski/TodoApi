using TodoList.Api.Client.Models.Responses.User;

namespace TodoList.Api.Client.Models.Response.User;

public class AddressApiResponse
{
    public string Street { get; set; }
    public string Suite { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public GeoApiResponse Geo { get; set; }
}
