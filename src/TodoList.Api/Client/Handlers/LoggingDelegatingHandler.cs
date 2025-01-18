namespace TodoList.Api.Client.Handlers;

public class LoggingDelegatingHandler
    : DelegatingHandler
{
    private readonly ILogger<LoggingDelegatingHandler> _logger;

    public LoggingDelegatingHandler(ILogger<LoggingDelegatingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
    HttpRequestMessage request,
    CancellationToken cancellationToken)
    {
        try
        {
            await LogRequestInfoAsync(request);

            var response = await base.SendAsync(request, cancellationToken);

            await LogResponseInfoAsync(response);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "HTTP request failed}: {Method} {Url}", request.Method, request.RequestUri);
            throw;
        }
    }

    private async Task LogRequestInfoAsync(HttpRequestMessage request)
    {
        _logger.LogInformation("Sending HTTP request: {Method} {URL}", request.Method, request.RequestUri);

        if (request.Content != null)
        {
            var requestContent = await request.Content.ReadAsStreamAsync();
            _logger.LogDebug("Request content: {Content}", requestContent);
        }

        if (request.Headers != null)
        {
            _logger.LogDebug("Request headers: {Headers}", request.Headers);
        }
    }

    private async Task LogResponseInfoAsync(HttpResponseMessage response)
    {
        _logger.LogInformation("Received HTTP response: {StatusCode})", response.StatusCode);

        if (response.Content != null)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogDebug("Response content: {Content}", responseContent);
        }

        if (response.Headers != null)
        {
            _logger.LogDebug("Response headers: {Headers}", response.Headers);
        }
    }
}
