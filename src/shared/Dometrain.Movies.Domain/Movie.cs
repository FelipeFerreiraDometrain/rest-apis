namespace Dometrain.Movies.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public required string Title { get; init; }
        public required int YearOfRelease { get; init; }
        public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
    }
}
