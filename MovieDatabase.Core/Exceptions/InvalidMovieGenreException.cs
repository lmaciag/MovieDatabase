using MovieDatabase.Core.Enums;

namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieGenreException : BaseException
{
    public InvalidMovieGenreException(MovieGenreEnum genre) : base($"Cannot set: {genre} as movie genre.")
    {
    }
}