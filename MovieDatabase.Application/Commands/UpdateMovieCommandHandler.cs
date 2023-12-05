using MediatR;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Commands;

public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMovieActorRepository _movieActorRepository;
    private readonly IMovieDirectorRepository _movieDirectorRepository;

    public UpdateMovieCommandHandler(IMovieRepository movieRepository, IMovieActorRepository movieActorRepository, IMovieDirectorRepository movieDirectorRepository)
    {
        _movieRepository = movieRepository;
        _movieActorRepository = movieActorRepository;
        _movieDirectorRepository = movieDirectorRepository;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (movie is null)
            throw new MovieNotFoundException(request.Id);
        
        var director = await _movieDirectorRepository.GetByIdAsync(request.UpdateParams.DirectorId, cancellationToken);

        if (director is null)
            throw new MovieDirectorNotFoundException(request.UpdateParams.DirectorId);

        var actors = await _movieActorRepository.GetAsync(cancellationToken, request.UpdateParams.ActorsIds);
        
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