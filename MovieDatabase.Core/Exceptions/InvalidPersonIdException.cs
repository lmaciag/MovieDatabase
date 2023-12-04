namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidPersonIdException : BaseException
{
    public Guid Id { get; }
    
    public InvalidPersonIdException(Guid id) : base($"Cannot set: {id} as person identifier.")
    {
        Id = id;
    }
}