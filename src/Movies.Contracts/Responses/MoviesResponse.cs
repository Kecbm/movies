namespace Movies.Contracts.Requests;

public class MovieResponse
{
    public required IEnumerable<MovieResponse> Items { get; init; } = Enumerable.Empty<MovieResponse>();
}