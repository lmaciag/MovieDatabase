using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieDirectorsQueryHandler : IRequestHandler<GetMovieDirectorsQuery, IEnumerable<MoviePersonDto>>
{
    private readonly IMovieDirectorRepository _movieDirectorRepository;

    public GetMovieDirectorsQueryHandler(IMovieDirectorRepository movieDirectorRepository)
    {
        _movieDirectorRepository = movieDirectorRepository;
    }

    public async Task<IEnumerable<MoviePersonDto>> Handle(GetMovieDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directors = await _movieDirectorRepository.GetAsync(cancellationToken);

        return directors.Select(x => new MoviePersonDto(x.Id, x.FirstName, x.LastName));
    }
}