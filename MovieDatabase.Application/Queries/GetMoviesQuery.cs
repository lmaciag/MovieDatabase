using MediatR;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Queries;

public sealed record GetMoviesQuery(MovieGenreEnum? Genre, Guid? DirectorId) : IRequest<IEnumerable<MovieItemDto>>;