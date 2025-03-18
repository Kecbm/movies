using Microsoft.AspNetCore.Mvc;
using Movies.Contracts.Requests;
using Movies.Application.Repositories;
using Movies.Application.Models;

namespace Movies.Api.Controllers;

[ApiController]
[Route("api")]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost("movies")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateMovieRequest request)
    {
        var movie = new Movie {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearOfRelease,
            Genres = request.Genres.ToList()
        };

        await _movieRepository.CreateAsync(movie);
        // The path: Headers.Location
        return Created($"api/movies/{movie.Id}", movie);
    }
}