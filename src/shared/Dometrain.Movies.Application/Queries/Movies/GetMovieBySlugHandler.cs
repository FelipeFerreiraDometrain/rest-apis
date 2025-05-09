using Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetMovieBySlugHandler : IGetMovieBySlugHandler
{
    public Task<Movie> HandleAsync(string slug, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}