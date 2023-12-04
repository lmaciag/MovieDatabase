namespace MovieDatabase.Core.Exceptions;

public sealed class InsufficientMovieActorsException : BaseException
{
    public InsufficientMovieActorsException() : base($"Insufficient number of actors")
    {
    }
}