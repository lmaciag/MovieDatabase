using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Infrastructure;

namespace MovieDatabase.Application.Commands;

public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly MovieDbContext _dbContext;

    public UpdateMovieCommandHandler(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _dbContext.Movies
            .Include(x => x.Director)
            .Include(x => x.Actors)
            .SingleOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        
        if (movie is null)
            throw new MovieNotFoundException(request.Id);
        
        var director = await _dbContext.Directors
            .SingleOrDefaultAsync(x => x.Id.Equals(request.UpdateParams.DirectorId), cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.UpdateParams.DirectorId);

        var actors = await _dbContext.Actors
            .Where(x => request.UpdateParams.ActorsIds.Contains(x.Id))
            .ToListAsync(cancellationToken);
        
        movie.UpdateTitle(request.UpdateParams.Title);
        movie.UpdateGenre(request.UpdateParams.Genre);
        movie.UpdateDirector(director);
        movie.UpdateReleaseDate(request.UpdateParams.ReleaseDate);
        movie.UpdateBoxOffice(request.UpdateParams.BoxOffice);
        movie.UpdateLength(request.UpdateParams.Length);
        movie.AssignActors(actors);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}