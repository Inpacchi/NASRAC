using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NASRAC.Persistence.Game.DAL;
using NASRAC.Services.Game.Services;

namespace NASRAC.Services.ConsoleApp;

class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"../../../../../API/NASRAC.API.Game"))
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
    
        var configuration = builder.Build();
        var serviceProvider = ConfigureServices(configuration);

        using var scope = serviceProvider.CreateScope();
        
        var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        await dataContext.Database.MigrateAsync();
        
        var raceWeekend = scope.ServiceProvider.GetRequiredService<RaceWeekend>();
        
        raceWeekend.Initialize();
    }
    
    private static IServiceProvider ConfigureServices(IConfiguration configuration)
    {
        var services = new ServiceCollection();
        
        services.AddSingleton<IConfiguration>(configuration);
        
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<DataContext>();

        services.AddTransient<RaceWeekend>();

        return services.BuildServiceProvider();
    }
}