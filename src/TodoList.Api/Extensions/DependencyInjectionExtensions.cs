using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using TodoList.Api.Client.Handlers;
using TodoList.Api.Client.Repositories;
using TodoList.Api.Configuration.Models;
using TodoList.Api.Database;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;
using TodoList.Api.Repositories;
using TodoList.Api.Services;
using TodoList.Api.Validators;

namespace TodoList.Api.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ExternalApiOptions>(configuration.GetSection("ExternalApi"));

        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGenNewtonsoftSupport();

        services.AddAutoMapper(typeof(Program));

        services.ConfigureDatasource(configuration);

        services.AddValidatorsFromAssemblyContaining<TodoItemValidator>();

        services.ConfigureHttpClient(configuration);

        services.AddScoped<IUserApiRepository, UserApiRepository>();

        services.AddScoped(typeof(IEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped<ITodoItemCategoryRepository, TodoItemCategoryRepository>();

        services.AddScoped(typeof(IEntityService<,,,>), typeof(BaseEntityService<,,,>));
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<ITodoItemCategoryService, TodoItemCategoryService>();

        services.AddExceptionHandlers();

        return services;
    }

    private static IServiceCollection ConfigureDatasource(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("The connection string 'DefaultConnection' was not found in configuration");

        services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }

    private static IServiceCollection ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<AuthenticationDelegatingHandler>();

        Uri baseAddress = configuration.GetValue<Uri>("ExternalApi:BaseUrl")
            ?? throw new InvalidOperationException("The 'ApiUrl' configuration property was not found in configuration");

        services.AddHttpClient("httpClient", client =>
        {
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }).AddHttpMessageHandler<AuthenticationDelegatingHandler>();

        return services;
    }
}
