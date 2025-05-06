using Dometrain.Movies.ApplicationAbstractions;
using ApplicationModel = Dometrain.Movies.Application.Models;
using Dometrain.Movies.Application.Bootstrap;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetMovieByIdHandler
{
    private readonly IMoviesRepository _moviesRepository;
    public GetMovieByIdHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public async Task<ApplicationModel.Movie> HandleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetByIdAsync(id, cancellationToken);
        if (movie is null)
        {
            throw new Exception("Not Found");
        }

        return movie.ToApplicationModel();
    }
}