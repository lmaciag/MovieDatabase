using MovieDatabase.Core.Entities;

namespace MovieDatabase.Core.Repositories;

public interface IMovieActorRepository
{
    Task<ICollection<MovieActor>> GetAsync(CancellationToken cancellationToken, ICollection<Guid>? guids = null);
    Task<MovieActor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}