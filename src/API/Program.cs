using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NASRAC.API.Extensions;
using NASRAC.Core.Entities.WebApp;
using NASRAC.Data.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddWebAppServices(builder.Configuration);
builder.Services.AddGameServices(builder.Configuration);
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "NASRAC API", 
        Description = "This API powers the NASRAC webgame, a modern take on the original game created by Kevin Minnelli.\n\n" +
                      "Inspired by the original NASRAC game, this platform provides a comprehensive racing management " +
                      "simulation experience, streamlining league management and race processing for drivers and team owners alike."
    }); 
    
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSwagger().RequireAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy => { policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"); });
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;


var dataContext = services.GetRequiredService<DataContext>();
var userManager = services.GetRequiredService<UserManager<AppUser>>();
var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    
await dataContext.Database.MigrateAsync();
await Seed.InitializeUsersAsync(userManager, roleManager);


app.Run();