using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetDirectorsQueryHandler : IRequestHandler<GetDirectorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly IMovieDirectorRepository _movieDirectorRepository;

    public GetDirectorsQueryHandler(IMovieDirectorRepository movieDirectorRepository)
    {
        _movieDirectorRepository = movieDirectorRepository;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directors = await _movieDirectorRepository.GetAsync(cancellationToken);

        return directors.Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName));
    }
}