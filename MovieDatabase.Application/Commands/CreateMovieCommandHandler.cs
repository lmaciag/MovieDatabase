using MediatR;
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
        var movieDirector = _dbContext.Directors.SingleOrDefault(x => x.Id.Equals(request.DirectorId));

        if (movieDirector is null)
            throw new MovieDirectorNotFoundException(request.DirectorId);
        
        var movie = new Movie(request.Title, request.Genre, movieDirector, request.ReleaseDate, request.BoxOffice, request.Length, new List<MovieActor>());
        
        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return movie.AsDto();
    }
}