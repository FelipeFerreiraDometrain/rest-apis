using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;
using Dometrain.Movies.Application.Bootstrap;
using ApplicationModel = Dometrain.Movies.Application.Models;

namespace Dometrain.Movies.Application.Queries.Movies;

public class CreateMovieHandler
{
    private readonly AppDbContext _dbContext;
    private readonly IMoviesRepository _moviesRepository;
    
    public CreateMovieHandler(AppDbContext dbContext, IMoviesRepository moviesRepository)
    {
        _dbContext = dbContext;
        _moviesRepository = moviesRepository;
    }

    public async Task<Guid> HandleAsync(ApplicationModel.Movie movie, CancellationToken cancellationToken = default)
    {
        var domain = movie.ToDomainModel();
        await _moviesRepository.CreateAsync(domain, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return domain.Id;
    }
}