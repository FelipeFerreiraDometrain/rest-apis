using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

public interface IGetMovieBySlugHandler
{
    Task<ApplicationModel.Movie> HandleAsync(string slug, CancellationToken cancellationToken = default);
}