namespace Movies.Contracts.Requests;

public class CreateMovieRequest
{
	public string Title { get; init; }
	public int YearOfRelease { get; init; }
	public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}
