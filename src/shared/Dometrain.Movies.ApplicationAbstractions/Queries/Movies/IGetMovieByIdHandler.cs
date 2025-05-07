using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

public interface IGetMovieByIdHandler
{
    Task<ApplicationModel.Movie> HandleAsync(Guid id, CancellationToken cancellationToken = default);
}