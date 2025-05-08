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
            return CreatedAtAction(nameof(GetMovieByIdAsync), new { id = id }, id);
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
        
        [ActionName(nameof(GetMovieByIdAsync))]
        [HttpGet(ApiEndpoints.Movies.Get)]
        public async Task<IActionResult> GetMovieByIdAsync([FromServices] IGetMovieByIdHandler handler, [FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var movie = await handler.HandleAsync(id, cancellationToken);
                var moviesResponse = movie.ToResponse();
                return Ok(moviesResponse);
            }
            catch (NotFoundException e)
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
            catch (NotFoundException e)
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
            catch (NotFoundException e)
            {
                _logger.LogInformation(e, "Could not find Movie in store by id: '{id}'", id);
            }
            return NoContent();
        }
    }
}