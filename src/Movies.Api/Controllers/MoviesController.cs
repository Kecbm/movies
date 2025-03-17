using Microsoft.AspNetCore.Mvc;
using Movies.Contracts.Requests;
using Movies.Application.Repositories;

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

    // Tornar os campos da request obrigatórios
    [HttpPost("movies")]
    public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
    {
        return Ok(request);
    }
}