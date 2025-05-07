using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.InMemoryDataStore.Context;
using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.ApplicationAbstractions.Extensions;

namespace Dometrain.Movies.Application.Queries.Movies;

public class CreateMovieHandler : ICreateMovieHandler
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