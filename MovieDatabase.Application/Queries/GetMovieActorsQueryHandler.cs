using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieActorsQueryHandler : IRequestHandler<GetMovieActorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly IMovieActorRepository _movieActorRepository;

    public GetMovieActorsQueryHandler(IMovieActorRepository movieActorRepository)
    {
        _movieActorRepository = movieActorRepository;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetMovieActorsQuery request, CancellationToken cancellationToken)
    {
        var actors = await _movieActorRepository.GetAsync(cancellationToken);

        return actors.Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName));
    }
}