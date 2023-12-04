using MovieDatabase.Core.Enums;

namespace MovieDatabase.Application.Params;

public sealed record UpdateMovieParams(string Title, MovieGenreEnum Genre, Guid DirectorId, DateOnly ReleaseDate, decimal BoxOffice, int Length, IEnumerable<Guid> ActorsIds);