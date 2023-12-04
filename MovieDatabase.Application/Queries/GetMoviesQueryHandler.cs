using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Enums;
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
        var moviesQuery = _dbContext.Movies.AsQueryable();

        if (request.Genre is not (null or MovieGenreEnum.None)) 
            moviesQuery = moviesQuery.Where(x => (MovieGenreEnum)x.Genre == request.Genre);

        if (request.DirectorId is not null)
            moviesQuery = moviesQuery.Where(x => (Guid)x.Director.Id == request.DirectorId);
        
        return await moviesQuery
            .Include(x => x.Director)
            .Select(x => new MovieItemDto(x.Id, x.Title, x.Genre, x.Director.Id, x.ReleaseDate))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}