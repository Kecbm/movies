namespace Movies.Contracts.Response;

public class MovieResponse
{
    public IEnumerable<MovieResponse> Items { get; init; } = Enumerable.Empty<MovieResponse>();
}