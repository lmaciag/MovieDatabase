using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Commands;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IDirectorRepository _directorRepository;

    public CreateMovieCommandHandler(IMovieRepository movieRepository, IActorRepository actorRepository, IDirectorRepository directorRepository)
    {
        _movieRepository = movieRepository;
        _actorRepository = actorRepository;
        _directorRepository = directorRepository;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var director = await _directorRepository.GetByIdAsync(request.DirectorId, cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.DirectorId);

        var actors = await _actorRepository.GetAsync(cancellationToken, request.ActorsIds);
        
        var movie = new Movie(request.Title, request.Genre, director, request.ReleaseDate, request.BoxOffice, request.Length, actors);

        await _movieRepository.AddAsync(movie, cancellationToken);

        return movie.AsDto();
    }
}