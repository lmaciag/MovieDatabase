using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Commands;

public sealed record CreateMovieCommand(string Title, MovieGenreEnum Genre, Guid DirectorId, DateOnly ReleaseDate, decimal BoxOffice, int Length, IEnumerable<Guid> ActorsIds) : IRequest<MovieDto>;