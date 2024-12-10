using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NASRAC.Core.Interfaces;
using NASRAC.Core.Services;

namespace NASRAC.Core.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddWebAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }

    public static IServiceCollection AddGameServices(this IServiceCollection services, IConfiguration config)
    {
        //services.AddTransient<IGameService, GameService>();

        return services;
    }

    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IDriverRepository, DriverRepository>();

        return services;
    }
}