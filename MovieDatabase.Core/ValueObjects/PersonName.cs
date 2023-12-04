using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record PersonName
{
    public string FirstName { get; }
    
    public string LastName { get; }

    public PersonName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new InvalidPersonNameException();

        FirstName = firstName;
        LastName = lastName;
    }
}