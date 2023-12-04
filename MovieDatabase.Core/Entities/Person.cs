using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Core.Entities;

public abstract class Person
{
    public PersonId Id { get; protected set; }
    
    public PersonName FirstName { get; protected set; }
    
    public PersonName LastName { get; protected set; }

    protected Person(PersonId id, PersonName firstName, PersonName lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}