namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidMovieIdException : BaseException
{
    public Guid Id { get; }
    
    public InvalidMovieIdException(Guid id) : base($"Cannot set: {id} as movie identifier.")
    {
        Id = id;
    }
}