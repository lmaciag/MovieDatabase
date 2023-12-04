using MediatR;
using MovieDatabase.Application.Dtos;

namespace MovieDatabase.Application.Queries;

public sealed record GetMovieQuery(Guid Id) : IRequest<MovieDto>;