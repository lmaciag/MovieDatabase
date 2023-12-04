using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieGenresQueryHandler : IRequestHandler<GetMovieGenresQuery, IEnumerable<MovieGenreItemDto>>
{
    public Task<IEnumerable<MovieGenreItemDto>> Handle(GetMovieGenresQuery request, CancellationToken cancellationToken)
    {
        var enums = Enum
            .GetValues(typeof(MovieGenreEnum))
            .Cast<MovieGenreEnum>()
            .Where(x => x is not MovieGenreEnum.None)
            .Select(x => new MovieGenreItemDto(x, x.ToString()));
        
        return Task.FromResult(enums);
    }
}