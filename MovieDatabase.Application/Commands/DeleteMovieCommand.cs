using MediatR;

namespace MovieDatabase.Application.Commands;

public sealed record DeleteMovieCommand(Guid Id) : IRequest;