using Microsoft.EntityFrameworkCore;
using TodoApi.Configs;
using TodoApi.Repository;

namespace TodoApi.Extensions;

public static class ServiceRegistratonExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<TodoDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IBaseEntityRepository<>), typeof(BaseEntityRepository<>));

        return services;
    }
}
