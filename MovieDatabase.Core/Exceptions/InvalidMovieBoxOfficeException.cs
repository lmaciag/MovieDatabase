namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieBoxOfficeException : BaseException
{
    public InvalidMovieBoxOfficeException(decimal value) : base($"Cannot set: {value} as box office value.")
    {
    }
}