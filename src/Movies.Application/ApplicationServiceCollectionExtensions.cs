namespace Movies.Application.Models;

// dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IMovieRepository, MovieRepository>();
        return services;
    }
}