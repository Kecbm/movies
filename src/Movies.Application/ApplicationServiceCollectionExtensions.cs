using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Repositories;
using Movies.Application.Database;
using Npgsql;

namespace Movies.Application;

// dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ =>  new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}