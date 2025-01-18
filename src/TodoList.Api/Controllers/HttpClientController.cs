using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Client.Models.Response.User;
using TodoList.Api.Client.Repositories;

namespace TodoList.Api.Controllers
{
    [Route("api/v1/httpclient")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private readonly IUserApiRepository _userApiRepository;

        public HttpClientController(IUserApiRepository userApiRepository)
        {
            _userApiRepository = userApiRepository;
        }

        [HttpGet("users")]
        public async Task<ActionResult<ICollection<UserApiResponse>>> GetUsersAsync()
        {
            var result = await _userApiRepository.GetUsersAsync();

            return Ok(result);
        }
    }
}
