using Dometrain.Movies.Application.Exceptions;
using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.ApplicationAbstractions.Extensions;
using Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetMovieBySlugHandler : IGetMovieBySlugHandler
{
    private readonly IMoviesRepository _moviesRepository;
    public GetMovieBySlugHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }
    
    public async Task<Movie> HandleAsync(string slug, CancellationToken cancellationToken = default)
    {
        var movie = await _moviesRepository.GetBySlugAsync(slug, cancellationToken);
        if (movie is null)
        {
            throw new NotFoundException();
        }

        return movie.ToApplicationModel();
    }
}