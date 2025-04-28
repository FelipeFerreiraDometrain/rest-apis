using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.Domain;
using Dometrain.Movies.InMemoryDataStore.Context;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.Movies.InMemoryDataStore.Services
{
    internal class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _appContext;

        public MoviesRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task CreateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _appContext.Movies.AddAsync(movie, cancellationToken);
        }


        public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _appContext.Movies.ToArrayAsync(cancellationToken);
        }

        public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _appContext.Movies.FirstOrDefaultAsync(m => m.Id.Equals(id), cancellationToken);
        }

        public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _appContext.Movies
                .ExecuteUpdateAsync(m => m
                    .SetProperty(movie => movie.Title, "updated title")
                    .SetProperty(movie => movie.Genres, Enumerable.Empty<string>()),
                cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var movie = await GetByIdAsync(id, cancellationToken);
            if (movie is not null)
            {
                _appContext.Movies.Remove(movie);
            }
        }
    }
}