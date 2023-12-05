using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _dbContext;

    public MovieRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Movie>> GetAsync(CancellationToken cancellationToken, MovieGenreEnum? genre = null, Guid? directorId = null)
    {
        var moviesQuery = _dbContext.Movies.AsQueryable();

        if (genre is not (null or MovieGenreEnum.None)) 
            moviesQuery = moviesQuery.Where(x => (MovieGenreEnum)x.Genre == genre);

        if (directorId is not null)
            moviesQuery = moviesQuery.Where(x => (Guid)x.Director.Id == directorId);
        
        return await moviesQuery
            .Include(x => x.Director)
            .ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Movies
            .Include(x => x.Director)
            .Include(x => x.Actors)
            .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    public async Task AddAsync(Movie movie, CancellationToken cancellationToken)
    {
        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Movie movie, CancellationToken cancellationToken)
    {
        _dbContext.Movies.Update(movie);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Movie movie, CancellationToken cancellationToken)
    {
        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}