namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieTitleException : BaseException
{
    public InvalidMovieTitleException() : base("Movie title is invalid.")
    {
    }
}