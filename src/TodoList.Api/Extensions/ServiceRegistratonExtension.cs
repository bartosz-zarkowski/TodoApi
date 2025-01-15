using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TodoList.Api.Configs;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;
using TodoList.Api.Repositories;
using TodoList.Api.Services;
using TodoList.Api.Validators;

namespace TodoList.Api.Extensions;

public static class ServiceRegistratonExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
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

        services.AddDbContext<TodoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddValidatorsFromAssemblyContaining<TodoItemValidator>();

        services.AddScoped(typeof(IEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped<ITodoItemCategoryRepository, TodoItemCategoryRepository>();

        services.AddScoped(typeof(IEntityService<,,,>), typeof(BaseEntityService<,,,>));
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<ITodoItemCategoryService, TodoItemCategoryService>();

        return services;
    }
}
