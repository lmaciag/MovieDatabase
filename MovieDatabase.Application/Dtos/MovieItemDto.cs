using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Dtos;

public sealed record MovieItemDto(Guid Id, string Title, MovieGenreEnum Genre, Guid DirectorId, DateOnly ReleaseDate);