using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<MovieItemDto>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<MovieItemDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        var movies = await _movieRepository.GetAsync(cancellationToken, request.Genre, request.DirectorId);

        return movies.Select(x => new MovieItemDto(x.Id, x.Title, x.Genre, x.Director.Id, x.ReleaseDate));
    }
}