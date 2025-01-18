using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace TodoList.Api.Exceptions.Handlers;

public class ValidationExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ValidationExceptionHandler> _logger;

    public ValidationExceptionHandler(ILogger<ValidationExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync
        (HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        _logger.LogError(
            validationException,
            "Exception occurred: {Message}",
            validationException.Message);

        var problemDetails = new
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad request",
            Errors = validationException.Errors.Select(error => new
            {
                Property = error.PropertyName,
                Message = error.ErrorMessage
            })
        };

        httpContext.Response.StatusCode = problemDetails.Status;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;

    }
}
