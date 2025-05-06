using Dometrain.Movies.Application.Queries.Movies;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddInMemoryDataStore()
                .AddScoped<CreateMovieHandler>()
                .AddScoped<GetAllMoviesHandler>()
                .AddScoped<GetMovieByIdHandler>()
                .AddScoped<DeleteMovieHandler>();
        }
    }
}