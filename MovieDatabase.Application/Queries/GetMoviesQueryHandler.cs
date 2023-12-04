using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Queries;

public sealed class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieItemDto>>
{
    private readonly MovieDbContext _dbContext;

    public GetMoviesQueryHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MovieItemDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Movies
            .Include(x => x.Director)
            .Select(x => new MovieItemDto(x.Id, x.Title, x.Genre, x.Director.Id, x.ReleaseDate))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}