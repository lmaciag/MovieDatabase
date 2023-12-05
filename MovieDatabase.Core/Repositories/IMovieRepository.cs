using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Enums;

namespace MovieDatabase.Core.Repositories;

public interface IMovieRepository
{
    Task<ICollection<Movie>> GetAsync(CancellationToken cancellationToken, MovieGenreEnum? genre = null, Guid? directorId = null);
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Movie movie, CancellationToken cancellationToken);
    Task UpdateAsync(Movie movie, CancellationToken cancellationToken);
    Task RemoveAsync(Movie movie, CancellationToken cancellationToken);
}