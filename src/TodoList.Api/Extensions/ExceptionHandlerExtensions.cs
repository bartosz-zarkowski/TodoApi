using TodoList.Api.Exceptions.Handlers;

namespace TodoList.Api.Extensions;

public static class ExceptionHandlerExtensions
{
    public static IServiceCollection AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddExceptionHandler<NotFoundExceptionHandler>();

        services.AddProblemDetails();
        
        return services;
    }
}
