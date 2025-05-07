using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;
using Dometrain.Movies.WebService.Contracts.Requests;
using Dometrain.Movies.WebService.Contracts.Response;
using Dometrain.Movies.WebService.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Dometrain.Movies.WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMovieAsync(ICreateMovieHandler handler, CreateMovieRequest movieRequest, CancellationToken cancellationToken = default)
        {
            var appModel = movieRequest.ToApplicationModel();
            var id = await handler.HandleAsync(appModel, cancellationToken);
            return Created($"/api/movies/{id}", id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync(IGetAllMoviesHandler handler, CancellationToken cancellationToken = default)
        {
            var movies = await handler.HandleAsync(cancellationToken);
            var moviesResponse = new MoviesResponse
            {
                Items = movies.Select(ContractMapping.ToMovieResponse)
            };
            return Ok(moviesResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMovieByIdAsync(IGetMovieByIdHandler handler, Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await handler.HandleAsync(id, cancellationToken);
            // TODO - exception handler here...
            if (movie is null)
            {
                return NotFound();
            }

            var moviesResponse = movie.ToMovieResponse();
            return Ok(moviesResponse);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMovieByIdAsync(IDeleteMovieHandler handler, Guid id, CancellationToken cancellationToken = default)
        {
            await handler.HandleAsync(id, cancellationToken);
            return Accepted();
        }
    }
}