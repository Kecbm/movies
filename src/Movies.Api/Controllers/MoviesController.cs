using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers;

[ApiController]
public class MoviesController : ControllerBase
{
    privare readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
}