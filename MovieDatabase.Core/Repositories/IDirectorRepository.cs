using MovieDatabase.Core.Entities;

namespace MovieDatabase.Core.Repositories;

public interface IDirectorRepository
{
    Task<ICollection<MovieDirector>> GetAsync(CancellationToken cancellationToken, ICollection<Guid>? guids = null);
    Task<MovieDirector?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}