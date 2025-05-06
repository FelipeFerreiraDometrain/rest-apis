using Dometrain.Movies.WebService.Contracts.Requests;
using Dometrain.Movies.WebService.Contracts.Response;
using ApplicationModel = Dometrain.Movies.Application.Models;

namespace Dometrain.Movies.WebService.Mapping
{
    public static class ContractMapping
    {

        public static ApplicationModel.Movie ToApplicationModel(this CreateMovieRequest movie)
        {
            return new ApplicationModel.Movie(Guid.Empty, movie.Title, movie.YearOfRelease, movie.Genres);
        }
        
        public static MovieResponse ToMovieResponse(this ApplicationModel.Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
                Genres = movie.Genres,
            };
        }
    }
}
