using Dometrain.Movies.Domain;

namespace Dometrain.Movies.ApplicationAbstractions;

public interface IMoviesRepository
{
    Task CreateAsync(Movie movie, CancellationToken cancellationToken = default);

    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default);

    Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default);

    Task DeleteAsync(Movie movie, CancellationToken cancellationToken = default);
}