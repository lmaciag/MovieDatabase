using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
{
    private readonly MovieDbContext _dbContext;

    public GetMovieQueryHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _dbContext.Movies
            .Include(x => x.Director)
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        
        if (movie is null)
            throw new MovieNotFoundException(request.Id);

        return movie.AsDto();
    }
}