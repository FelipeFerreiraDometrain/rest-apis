using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.WebService.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace Dometrain.Movies.WebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync(IMoviesRepository moviesRepository, CancellationToken ct = default)
        {
            var allMovies = await moviesRepository.GetAllAsync(ct);
            var moviesResponse = new MoviesResponse
            {
                Items = allMovies.Select(movie => new MovieResponse
                {
                    Genres = movie.Genres,
                    Id = movie.Id,
                    Title = movie.Title,
                    YearOfRelease = movie.YearOfRelease,
                })
            };
            return Ok(moviesResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, IMoviesRepository moviesRepository, CancellationToken ct = default)
        {
            var movie = await moviesRepository.GetByIdAsync(id, ct);
            if (movie is null)
            {
                return NotFound();
            }

            var moviesResponse = new MovieResponse
            {
                Genres = movie.Genres,
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            };
            return Ok(moviesResponse);
        }
    }
}
