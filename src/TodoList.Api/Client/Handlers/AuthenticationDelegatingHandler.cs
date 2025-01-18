using Microsoft.Extensions.Options;
using TodoList.Api.Configuration.Models;

namespace TodoList.Api.Client.Handlers;

public class AuthenticationDelegatingHandler
    : DelegatingHandler
{
    private readonly ExternalApiOptions _externalApiOptions;

    public AuthenticationDelegatingHandler(IOptions<ExternalApiOptions> options)
    {
        _externalApiOptions = options.Value;
    }

    protected override Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
    {
        request.Headers.Add("X-API-KEY", _externalApiOptions.ApiKey);

        return base.SendAsync(request, cancellationToken);
    }
}
