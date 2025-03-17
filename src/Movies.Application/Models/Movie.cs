namespace Movies.Application.Models;

public class Movie
{
    public Guid Id { get; init; }
    public string Title { get; init; }
	public int YearOfRelease { get; init; }
    public List<string> Genres { get; init; } = new();
}