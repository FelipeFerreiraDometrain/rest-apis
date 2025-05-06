namespace Dometrain.Movies.Application.Models;

public record Movie(
    Guid Id,
    string Title,
    int YearOfRelease,
    IEnumerable<string> Genres
);