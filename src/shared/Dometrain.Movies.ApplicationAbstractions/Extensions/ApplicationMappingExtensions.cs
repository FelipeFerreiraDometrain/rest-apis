using ApplicationModel = Dometrain.Movies.ApplicationAbstractions.Models;

namespace Dometrain.Movies.ApplicationAbstractions.Extensions;

public static class ApplicationMappingExtensions
{
    public static ApplicationModel.Movie ToApplicationModel(this Domain.Movie movie)
    {
        return new ApplicationModel.Movie
        {
            Genres = movie.Genres,
            Id = movie.Id,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
        };
    }
    
    public static Domain.Movie ToDomainModel(this ApplicationModel.Movie movie)
    {
        return new Domain.Movie
        {
            Genres = movie.Genres,
            Title = movie.Title,
            YearOfRelease = movie.YearOfRelease,
            Slug = movie.Slug,
            Id = movie.Id,
        };
    }
}