using Dometrain.Movies.Application.Exceptions;
using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.InMemoryDataStore.Context;

namespace Dometrain.Movies.Application.Queries.Movies;

public class DeleteMovieHandler : IDeleteMovieHandler
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
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
        if (movie is null)
        {
            throw new NotFoundException();
        }
        await _moviesRepository.DeleteAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}