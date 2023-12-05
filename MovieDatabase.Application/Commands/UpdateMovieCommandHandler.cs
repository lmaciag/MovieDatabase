using MediatR;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Commands;

public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IActorRepository _actorRepository;
    private readonly IDirectorRepository _directorRepository;

    public UpdateMovieCommandHandler(IMovieRepository movieRepository, IActorRepository actorRepository, IDirectorRepository directorRepository)
    {
        _movieRepository = movieRepository;
        _actorRepository = actorRepository;
        _directorRepository = directorRepository;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (movie is null)
            throw new MovieNotFoundException(request.Id);
        
        var director = await _directorRepository.GetByIdAsync(request.UpdateParams.DirectorId, cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.UpdateParams.DirectorId);

        var actors = await _actorRepository.GetAsync(cancellationToken, request.UpdateParams.ActorsIds);
        
        movie.UpdateTitle(request.UpdateParams.Title);
        movie.UpdateGenre(request.UpdateParams.Genre);
        movie.UpdateDirector(director);
        movie.UpdateReleaseDate(request.UpdateParams.ReleaseDate);
        movie.UpdateBoxOffice(request.UpdateParams.BoxOffice);
        movie.UpdateLength(request.UpdateParams.Length);
        movie.AssignActors(actors);

        await _movieRepository.UpdateAsync(movie, cancellationToken);
    }
}