namespace MovieDatabase.Core.Exceptions;

public sealed class InvalidPersonNameException : BaseException
{
    public InvalidPersonNameException() : base("Person name is invalid.")
    {
    }
}