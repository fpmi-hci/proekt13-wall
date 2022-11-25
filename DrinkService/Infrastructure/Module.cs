using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Module
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddEntityFrameworkNpgsql()
            .AddDbContext<DrinkServiceDbContext>(dbContext =>
                dbContext.UseNpgsql("Server=127.0.0.1;Port=5432;User Id=postgres;Password=root;Database=DrinkChoice;"), ServiceLifetime.Transient);//Environment.GetEnvironmentVariable("pg_endpoint")

        return services;
    }
}