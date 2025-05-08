using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Commands.Movies;

public interface IUpdateMovieHandler
{
    Task HandleAsync(ApplicationModel.Movie movie, CancellationToken cancellationToken = default);
}