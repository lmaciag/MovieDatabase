using MediatR;
using MovieDatabase.Application.Params;

namespace MovieDatabase.Application.Commands;

public sealed record UpdateMovieCommand(Guid Id, UpdateMovieParams UpdateParams) : IRequest;