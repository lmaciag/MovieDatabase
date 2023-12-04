using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Dtos;

public sealed record MovieDto(Guid Id, string Title, MovieGenreEnum Genre, Guid DirectorId, DateOnly ReleaseDate, decimal BoxOffice, int Length);