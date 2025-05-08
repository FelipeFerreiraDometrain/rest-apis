using Dometrain.Movies.WebService.Contracts.Requests;
using Dometrain.Movies.WebService.Contracts.Response;
using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.WebService.Mapping
{
    public static class ContractMapping
    {

        public static ApplicationModel.Movie ToApplication(this CreateMovieRequest movie)
        {
            return new ApplicationModel.Movie(Guid.Empty, movie.Title, movie.YearOfRelease, movie.Genres);
        }
        
        public static ApplicationModel.Movie ToApplication(this UpdateMovieRequest movie, Guid id)
        {
            return new ApplicationModel.Movie(id, movie.Title, movie.YearOfRelease, movie.Genres);
        }
        
        public static MovieResponse ToResponse(this ApplicationModel.Movie movie)
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
