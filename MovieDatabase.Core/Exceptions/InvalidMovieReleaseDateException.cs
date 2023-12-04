namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieReleaseDateException : BaseException
{
    public InvalidMovieReleaseDateException(DateOnly releaseDate) : base($"Cannot set: {releaseDate} as movie release date.")
    {
    }
}