using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Core.Entities;

public abstract class Person
{
    public PersonId Id { get; protected set; }
    
    public PersonName Name { get; protected set; }

    protected Person(PersonId id, PersonName name)
    {
        Id = id;
        Name = name;
    }
}