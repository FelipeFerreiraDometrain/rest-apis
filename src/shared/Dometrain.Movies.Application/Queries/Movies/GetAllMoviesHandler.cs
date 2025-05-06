using Dometrain.Movies.ApplicationAbstractions;
using ApplicationModel = Dometrain.Movies.Application.Models;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetAllMoviesHandler
{
    private readonly IMoviesRepository _moviesRepository;

    public GetAllMoviesHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public async Task<IEnumerable<ApplicationModel.Movie>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetAllAsync(cancellationToken);
        return movies.Select(Bootstrap.ApplicationMappingExtensions.ToApplicationModel);
    }
}