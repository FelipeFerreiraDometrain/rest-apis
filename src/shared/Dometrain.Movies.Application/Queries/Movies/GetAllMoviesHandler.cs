using Dometrain.Movies.ApplicationAbstractions;
using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.ApplicationAbstractions.Extensions;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetAllMoviesHandler : IGetAllMoviesHandler
{
    private readonly IMoviesRepository _moviesRepository;

    public GetAllMoviesHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public async Task<IEnumerable<ApplicationModel.Movie>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var movies = await _moviesRepository.GetAllAsync(cancellationToken);
        return movies.Select(ApplicationMappingExtensions.ToApplicationModel);
    }
}