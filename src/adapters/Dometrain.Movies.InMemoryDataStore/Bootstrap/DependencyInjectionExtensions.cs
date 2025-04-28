using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;
using Dometrain.Movies.InMemoryDataStore.Services;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInMemoryDataStore(this IServiceCollection services)
        {
            return services
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlite();
                })
                .AddScoped<IMoviesRepository, MoviesRepository>();
        }
    }
}
