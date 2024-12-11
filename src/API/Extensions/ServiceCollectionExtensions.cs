using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NASRAC.API.Services;
using NASRAC.API.Services.Interfaces;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Services;
using NASRAC.Data.DAL;
using NASRAC.Data.Repository;

namespace NASRAC.API.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddWebAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }

    public static IServiceCollection AddGameServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IGameService, GameService>();

        return services;
    }

    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<DataContext>();
        
        services.AddTransient<IDriverRepository, DriverRepository>();

        return services;
    }
}