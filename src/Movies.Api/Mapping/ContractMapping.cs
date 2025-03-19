using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Mapping;

public static class ContractMapping
{
    public static Movie MapToMovie(this CreateMovieRequest request)
    {
        // Transform a object from the request to the domain model
        return new Movie {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            Genres = request.Genres.ToList()
        };
    }

    public static MovieResponse MapToResponseMovie(this Movie movie)
    {
        return new MovieResponse {
            Id = movie.Id,
            Title = movie.Title,
            Slug = movie.Slug,
            YearOfRelease = movie.YearOfRelease,
            Genres = movie.Genres
        };
    }

    public static MoviesResponse MapToResponseMovies(this IEnumerable<Movie> movies)
    {
        return new MoviesResponse {
            Items = movies.Select(movie => movie.MapToResponseMovie())
        };
    }

    public static Movie MapToUpdateMovie(this UpdateMovieRequest request, Guid id)
    {
        return new Movie {
            Id = id,
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            Genres = request.Genres.ToList()
        };
    }
}