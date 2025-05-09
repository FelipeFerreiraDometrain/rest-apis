using Dometrain.Movies.Application.Exceptions;
using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;
using Dometrain.Movies.WebService.Contracts.Requests;
using Dometrain.Movies.WebService.Contracts.Response;
using Dometrain.Movies.WebService.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Dometrain.Movies.WebService.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost(ApiEndpoints.Movies.Create)]
        public async Task<IActionResult> CreateMovieAsync([FromServices] ICreateMovieHandler handler, [FromBody] CreateMovieRequest movieRequest, CancellationToken cancellationToken = default)
        {
            var appModel = movieRequest.ToApplication();
            var id = await handler.HandleAsync(appModel, cancellationToken);
            return CreatedAtAction(nameof(GetMovieByIdOrSlugAsync), new { idOrSlug = id }, id);
        }

        [HttpGet(ApiEndpoints.Movies.GetAll)]
        public async Task<IActionResult> GetAllMoviesAsync([FromServices] IGetAllMoviesHandler handler, CancellationToken cancellationToken = default)
        {
            var movies = await handler.HandleAsync(cancellationToken);
            var moviesResponse = new MoviesResponse
            {
                Items = movies.Select(ContractMapping.ToResponse)
            };
            return Ok(moviesResponse);
        }
        
        
        [ActionName(nameof(GetMovieByIdOrSlugAsync))]
        [HttpGet(ApiEndpoints.Movies.GetByIdOrSlug)]
        public async Task<IActionResult> GetMovieByIdOrSlugAsync([FromServices] IGetMovieBySlugHandler getBySlugHandler, [FromServices] IGetMovieByIdHandler getByIdHandler, [FromRoute] string idOrSlug, CancellationToken cancellationToken = default)
        {
            try
            {
                ApplicationAbstractions.Models.Movie movie;
                if (Guid.TryParse(idOrSlug, out var id))
                {
                    movie = await getByIdHandler.HandleAsync(id, cancellationToken);
                }
                else
                {
                    movie = await getBySlugHandler.HandleAsync(idOrSlug, cancellationToken);
                }
                return Ok(movie.ToResponse());
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
        
        [HttpPut(ApiEndpoints.Movies.Update)]
        public async Task<IActionResult> UpdateMovieByIdAsync([FromServices] IUpdateMovieHandler handler, [FromRoute] Guid id, [FromBody] UpdateMovieRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var movie = request.ToApplication(id);
                await handler.HandleAsync(movie, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        [HttpDelete(ApiEndpoints.Movies.Delete)]
        public async Task<IActionResult> DeleteMovieByIdAsync([FromServices] IDeleteMovieHandler handler, [FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                await handler.HandleAsync(id, cancellationToken);
            }
            catch (NotFoundException)
            {
                _logger.LogInformation("Could not find Movie in store by id: '{id}'", id);
            }
            return NoContent();
        }
    }
}