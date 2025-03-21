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
        return CreatedAtAction(nameof(GetAsync), new { idOrSlug = movie.Id }, movie);
    }

    [HttpGet(ApiEndpoints.Movies.Get)]
    [ActionName(nameof(GetAsync))]
    public async Task<IActionResult> GetAsync([FromRoute] string idOrSlug)
    {
        // var movie = await _movieRepository.GetByIdAsync(id);

        var movie = Guid.TryParse(idOrSlug, out var id)
            ? await _movieRepository.GetByIdAsync(id)
            : await _movieRepository.GetBySlugAsync(idOrSlug);

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

    [HttpPut(ApiEndpoints.Movies.Update)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateMovieRequest request)
    {
        var movie = request.MapToUpdateMovie(id);

        var updated = await _movieRepository.UpdateAsync(movie);

        if (updated == null)
        {
            return NotFound();
        }

        var response = movie.MapToResponseMovie();

        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Movies.Delete)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var deleted = await _movieRepository.DeleteByIdAsync(id);

        if (deleted == null)
        {
            return NotFound();
        }

        return Ok();
    }
}