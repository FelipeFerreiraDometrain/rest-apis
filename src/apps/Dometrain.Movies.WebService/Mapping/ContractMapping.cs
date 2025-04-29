using Dometrain.Movies.Domain;
using Dometrain.Movies.WebService.Contracts.Requests;
using Dometrain.Movies.WebService.Contracts.Response;

namespace Dometrain.Movies.WebService.Mapping
{
    public static class ContractMapping
    {
        public static Movie ToMovie(this CreateMovieRequest movieRequest)
        {
            return new Movie
            {
                Title = movieRequest.Title,
                YearOfRelease = movieRequest.YearOfRelease,
                Genres = movieRequest.Genres.ToList(),
            };
        }

        public static MovieResponse ToMovieResponse(this Movie movie)
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
