using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Queries;

public sealed class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (movie is null)
            throw new MovieNotFoundException(request.Id);

        return movie.AsDto();
    }
}