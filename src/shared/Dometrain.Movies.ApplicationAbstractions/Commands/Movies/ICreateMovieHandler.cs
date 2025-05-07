using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Commands.Movies;

public interface ICreateMovieHandler
{
    Task<Guid> HandleAsync(ApplicationModel.Movie movie, CancellationToken cancellationToken = default);
}