using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;
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
        public async Task<IActionResult> CreateMovieAsync(AppDbContext dbContext, IMoviesRepository moviesRepository, CreateMovieRequest movieRequest, CancellationToken cancellationToken = default)
        {
            var movie = movieRequest.ToMovie();
            await moviesRepository.CreateAsync(movie, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Created($"/api/movies/{movie.Id}", movie.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync(IMoviesRepository moviesRepository, CancellationToken cancellationToken = default)
        {
            var allMovies = await moviesRepository.GetAllAsync(cancellationToken);
            var moviesResponse = new MoviesResponse
            {
                Items = allMovies.Select(ContractMapping.ToMovieResponse)
            };
            return Ok(moviesResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMovieByIdAsync(Guid id, IMoviesRepository moviesRepository, CancellationToken cancellationToken = default)
        {
            var movie = await moviesRepository.GetByIdAsync(id, cancellationToken);
            if (movie is null)
            {
                return NotFound();
            }

            var moviesResponse = movie.ToMovieResponse();
            return Ok(moviesResponse);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMovieByIdAsync(AppDbContext dbContext, IMoviesRepository moviesRepository, Guid id, CancellationToken cancellationToken = default)
        {
            await moviesRepository.DeleteAsync(id, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Accepted();
        }
    }
}