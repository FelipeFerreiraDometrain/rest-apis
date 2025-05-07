using Dometrain.Movies.Application.Exceptions;
using Dometrain.Movies.ApplicationAbstractions;
using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;
using Dometrain.Movies.ApplicationAbstractions.Extensions;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

namespace Dometrain.Movies.Application.Queries.Movies;

public class GetMovieByIdHandler : IGetMovieByIdHandler
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
            throw new NotFoundException();
        }

        return movie.ToApplicationModel();
    }
}