using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

public interface IGetAllMoviesHandler
{
    Task<IEnumerable<ApplicationModel.Movie>> HandleAsync(CancellationToken cancellationToken = default);
}