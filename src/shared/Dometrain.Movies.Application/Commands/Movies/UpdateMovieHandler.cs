using Dometrain.Movies.Application.Exceptions;
using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.ApplicationAbstractions.Extensions;
using Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.InMemoryDataStore.Context;

namespace Dometrain.Movies.Application.Queries.Movies;

public class UpdateMovieHandler : IUpdateMovieHandler
{
    private readonly AppDbContext _dbContext;
    private readonly IMoviesRepository _moviesRepository;

    public UpdateMovieHandler(AppDbContext dbContext, IMoviesRepository moviesRepository)
    {
        _dbContext = dbContext;
        _moviesRepository = moviesRepository;
    }
    public async Task HandleAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        var domain = movie.ToDomainModel();
        var existingMovie = await _moviesRepository.GetByIdAsync(movie.Id, cancellationToken);
        if (existingMovie is null)
        {
            throw new NotFoundException();
        }
        await _moviesRepository.UpdateAsync(domain, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}