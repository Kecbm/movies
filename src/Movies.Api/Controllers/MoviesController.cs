using Microsoft.AspNetCore.Mvc;
using Movies.Contracts.Requests;
using Movies.Application.Repositories;
using Movies.Application.Models;
using Movies.Api.Mapping;

namespace Movies.Api.Controllers;

[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost(ApiEndpoints.Movies.Create)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateMovieRequest request)
    {
        var movie = request.MapToMovie();

        await _movieRepository.CreateAsync(movie);

        // The path: Headers.Location
        // return Created($"/{ApiEndpoints.Movies.Create}/{movie.Id}", movie);

        // Headers.Location is the path to the new resource
        return CreatedAtAction(nameof(GetAsync), new { id = movie.Id }, movie);
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        var response = movie.MapToResponseMovie();

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Movies.GetAll)]
    public async Task<IActionResult> GetAllAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        var response = movies.MapToResponseMovies();

        return Ok(response);
    }
}