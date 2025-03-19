namespace Movies.Contracts.Responses;

public class MovieResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Slug { get; init; }
	public int YearOfRelease { get; init; }
	public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}