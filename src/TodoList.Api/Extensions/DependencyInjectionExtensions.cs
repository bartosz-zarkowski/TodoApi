using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGenNewtonsoftSupport();

        services.AddAutoMapper(typeof(Program));

        services.ConfigureDatasource(configuration);

        services.AddValidatorsFromAssemblyContaining<TodoItemValidator>();

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
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(connectionString));
        return services;
    }
}
