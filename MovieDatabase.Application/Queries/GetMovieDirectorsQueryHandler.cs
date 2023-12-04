using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieDirectorsQueryHandler : IRequestHandler<GetMovieDirectorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly MovieDbContext _dbContext;

    public GetMovieDirectorsQueryHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetMovieDirectorsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Directors
            .Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}