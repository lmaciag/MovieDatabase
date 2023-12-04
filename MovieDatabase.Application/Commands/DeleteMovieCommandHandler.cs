using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Commands;

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly MovieDbContext _dbContext;

    public DeleteMovieCommandHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _dbContext.Movies
            .SingleOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);

        if (movie is null)
            throw new MovieNotFoundException(request.Id);

        _dbContext.Movies.Remove(movie);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}