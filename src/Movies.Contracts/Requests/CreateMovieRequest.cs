using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Requests;

public class CreateMovieRequest
{
	[Required(ErrorMessage = "The Title is required")]
	public string Title { get; init; }
	[Required(ErrorMessage = "The YearOfRelease is required")]
	public int YearOfRelease { get; init; }
	[MinLength(1, ErrorMessage = "The Genres is required")]
	public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}
