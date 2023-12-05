using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Infrastructure.Repositories;

public class MovieDirectorRepository : IMovieDirectorRepository
{
    private readonly MovieDbContext _dbContext;

    public MovieDirectorRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<MovieDirector>> GetAsync(CancellationToken cancellationToken, ICollection<Guid>? guids = null)
    {
        var directorsQuery = _dbContext.Directors.AsQueryable();

        if (guids is not null && guids.Count > 0)
            directorsQuery = directorsQuery.Where(x => guids.Contains(x.Id));
            
        return await directorsQuery.ToListAsync(cancellationToken);
    }

    public async Task<MovieDirector?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Directors
            .SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }
}