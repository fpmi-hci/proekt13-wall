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
                dbContext.UseNpgsql(Environment.GetEnvironmentVariable("pg_endpoint")), ServiceLifetime.Transient);

        return services;
    }
}