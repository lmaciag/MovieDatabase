using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Entities;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Commands;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly MovieDbContext _dbContext;

    public CreateMovieCommandHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var director = await _dbContext.Directors
            .SingleOrDefaultAsync(x => x.Id.Equals(request.DirectorId), cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.DirectorId);

        var actors = await _dbContext.Actors
            .Where(x => request.ActorsIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
        
        var movie = new Movie(request.Title, request.Genre, director, request.ReleaseDate, request.BoxOffice, request.Length, actors);
        
        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return movie.AsDto();
    }
}