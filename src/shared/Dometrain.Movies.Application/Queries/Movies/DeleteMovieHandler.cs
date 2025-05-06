using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;

namespace Dometrain.Movies.Application.Queries.Movies;

public class DeleteMovieHandler
{
    private readonly AppDbContext _dbContext;
    private readonly IMoviesRepository _moviesRepository;
    
    public DeleteMovieHandler(AppDbContext dbContext, IMoviesRepository moviesRepository)
    {
        _dbContext = dbContext;
        _moviesRepository = moviesRepository;
    }

    public async Task HandleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // TODO - locate movie...
        await _moviesRepository.DeleteAsync(id, cancellationToken);
        // send movie ref to delete...
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}