using Dometrain.Movies.Application.Queries.Movies;
using Dometrain.Movies.ApplicationAbstractions.Commands.Movies;
using Dometrain.Movies.ApplicationAbstractions.Queries.Movies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddInMemoryDataStore()
                .AddScoped<ICreateMovieHandler, CreateMovieHandler>()
                .AddScoped<IGetAllMoviesHandler, GetAllMoviesHandler>()
                .AddScoped<IGetMovieBySlugHandler, GetMovieBySlugHandler>()
                .AddScoped<IGetMovieByIdHandler, GetMovieByIdHandler>()
                .AddScoped<IUpdateMovieHandler, UpdateMovieHandler>()
                .AddScoped<IDeleteMovieHandler, DeleteMovieHandler>();
        }
    }
}