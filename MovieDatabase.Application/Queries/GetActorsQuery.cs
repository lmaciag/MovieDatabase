using MediatR;
using MovieDatabase.Application.Dtos;

namespace MovieDatabase.Application.Queries;

public sealed record GetActorsQuery : IRequest<IEnumerable<MoviePersonDto>>;