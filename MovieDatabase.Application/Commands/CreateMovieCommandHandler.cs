using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Commands;

public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDto>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieActorRepository _movieActorRepository;
    private readonly IMovieDirectorRepository _movieDirectorRepository;

    public CreateMovieCommandHandler(IMovieRepository movieRepository, IMovieActorRepository movieActorRepository, IMovieDirectorRepository movieDirectorRepository)
    {
        _movieRepository = movieRepository;
        _movieActorRepository = movieActorRepository;
        _movieDirectorRepository = movieDirectorRepository;
    }

    public async Task<MovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var director = await _movieDirectorRepository.GetByIdAsync(request.DirectorId, cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.DirectorId);

        var actors = await _movieActorRepository.GetAsync(cancellationToken, request.ActorsIds);
        
        var movie = new Movie(request.Title, request.Genre, director, request.ReleaseDate, request.BoxOffice, request.Length, actors);

        await _movieRepository.AddAsync(movie, cancellationToken);

        return movie.AsDto();
    }
}