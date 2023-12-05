using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Infrastructure.Repositories;

public class ActorRepository : IActorRepository
{
    private readonly MovieDbContext _dbContext;

    public ActorRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<MovieActor>> GetAsync(CancellationToken cancellationToken, ICollection<Guid>? guids = null)
    {
        var directorsQuery = _dbContext.Actors.AsQueryable();

        if (guids is not null && guids.Count > 0)
            directorsQuery = directorsQuery.Where(x => guids.Contains(x.Id));
            
        return await directorsQuery.ToListAsync(cancellationToken);
    }

    public async Task<MovieActor?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Actors
            .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }
}