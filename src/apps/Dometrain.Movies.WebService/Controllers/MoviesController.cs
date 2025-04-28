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
    }
}
