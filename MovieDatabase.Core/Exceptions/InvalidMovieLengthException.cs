namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieLengthException : BaseException
{
    public InvalidMovieLengthException(int length) : base($"Cannot set: {length} as movie length.")
    {
    }
}