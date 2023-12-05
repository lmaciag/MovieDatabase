using MediatR;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Commands;

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);

        if (movie is null)
            throw new MovieNotFoundException(request.Id);

        await _movieRepository.RemoveAsync(movie, cancellationToken);
    }
}