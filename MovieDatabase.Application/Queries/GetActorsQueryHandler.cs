using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetActorsQueryHandler : IRequestHandler<GetActorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly IActorRepository _actorRepository;

    public GetActorsQueryHandler(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
    {
        var actors = await _actorRepository.GetAsync(cancellationToken);

        return actors.Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName));
    }
}