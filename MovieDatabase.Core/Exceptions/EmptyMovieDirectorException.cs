namespace MovieDatabase.Core.Exceptions;

public sealed class EmptyMovieDirectorException : BaseException
{
    public EmptyMovieDirectorException() : base("Movie director is empty.")
    {
    }
}