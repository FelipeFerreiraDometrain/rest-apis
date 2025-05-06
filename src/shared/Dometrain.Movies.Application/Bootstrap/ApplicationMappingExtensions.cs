using ApplicationModel = Dometrain.Movies.Application.Models;

namespace Dometrain.Movies.Application.Bootstrap;

public static class ApplicationMappingExtensions
{
    public static ApplicationModel.Movie ToApplicationModel(this Domain.Movie movie)
    {
        return new ApplicationModel.Movie(movie.Id, movie.Title, movie.YearOfRelease, movie.Genres);
    }
    
    public static Domain.Movie ToDomainModel(this ApplicationModel.Movie movie)
    {
        return new Domain.Movie
        {
            Id = movie.Id,
            Genres = movie.Genres,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease
        };
    }
}