using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieActorsQueryHandler : IRequestHandler<GetMovieActorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly MovieDbContext _dbContext;

    public GetMovieActorsQueryHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetMovieActorsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Actors
            .Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}