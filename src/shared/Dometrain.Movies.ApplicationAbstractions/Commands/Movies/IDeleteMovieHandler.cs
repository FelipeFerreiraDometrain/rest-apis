namespace Dometrain.Movies.ApplicationAbstractions.Commands.Movies;

public interface IDeleteMovieHandler
{
    Task HandleAsync(Guid id, CancellationToken cancellationToken = default);
}