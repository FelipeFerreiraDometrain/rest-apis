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
        
        public async Task<Movie?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            return await _appContext.Movies.FirstOrDefaultAsync(m => m.Slug.Equals(slug), cancellationToken);
        }

        public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            await _appContext.Movies
                .Where(m => m.Id == movie.Id)
                    .ExecuteUpdateAsync(setters => setters
                            .SetProperty(m => m.Title, movie.Title)
                            .SetProperty(m => m.YearOfRelease, movie.YearOfRelease)
                            .SetProperty(m => m.Genres, movie.Genres),
                        cancellationToken);
        }

        public async Task DeleteAsync(Movie movie, CancellationToken cancellationToken = default)
        {
            _appContext.Movies.Remove(movie);
        }
    }
}