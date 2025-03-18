namespace Movies.Contracts.Responses;

public class MoviesResponse
{
    public IEnumerable<MovieResponse> Items { get; init; } = Enumerable.Empty<MovieResponse>();
}