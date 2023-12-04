using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Dtos;

public sealed record MovieGenreItemDto(MovieGenreEnum Id, string Name);