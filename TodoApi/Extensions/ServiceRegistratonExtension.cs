using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TodoApi.Configs;
using TodoApi.Interfaces.Repositories;
using TodoApi.Interfaces.Services;
using TodoApi.Repository;
using TodoApi.Services;

namespace TodoApi.Extensions;

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

        services.AddScoped(typeof(IEntityRepository<>), typeof(BaseEntityRepository<>));
        services.AddScoped(typeof(IEntityService<,,,>), typeof(BaseEntityService<,,,>));
        services.AddScoped<ITodoItemService, TodoItemService>();

        return services;
    }
}
