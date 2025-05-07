namespace Dometrain.Movies.ApplicationAbstractions.Models;

public record Movie(
    Guid Id,
    string Title,
    int YearOfRelease,
    IEnumerable<string> Genres
);