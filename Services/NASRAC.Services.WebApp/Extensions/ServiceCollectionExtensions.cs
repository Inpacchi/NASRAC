﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NASRAC.Services.WebApp.Interfaces;
using NASRAC.Services.WebApp.Services;

namespace NASRAC.Services.WebApp.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddWebAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<ITokenService, TokenService>();

        return services;
    }
}