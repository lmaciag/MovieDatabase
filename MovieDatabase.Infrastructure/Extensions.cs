using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieDatabase.Core.Repositories;
using MovieDatabase.Infrastructure.Middlewares;
using MovieDatabase.Infrastructure.Repositories;

namespace MovieDatabase.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSingleton<ExceptionMiddleware>();
        services.AddHttpContextAccessor();
        services.AddDatabaseContext(configuration);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IActorRepository, ActorRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();

        return services;
    }
    
    public static async Task<WebApplication> UseInfrastructureAsync(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        await app.ApplyMigrationsAsync();
        
        return app;
    }

    private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        const string connectionStringName = "DatabaseConnection";
        return services.AddDbContext<MovieDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString(connectionStringName));
        });
    }

    private static async Task ApplyMigrationsAsync(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
        await db.Database.MigrateAsync();
    }
}