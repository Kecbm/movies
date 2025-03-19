using System.Text.RegularExpressions;

namespace Movies.Application.Models;

public class Movie
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Slug => GenerateSlug();
	public int YearOfRelease { get; init; }
    public List<string> Genres { get; init; } = new();

    private string GenerateSlug()
    {
        var sluggedTitle = Regex.Replace(Title, "[^0-9A-Za-z _-]", string.Empty)
            .ToLower().Replace(" ", "-");

        return $"{sluggedTitle}-{YearOfRelease}";
    }
}