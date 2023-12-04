using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Core.Entities;

public sealed class MovieActor : Person
{
    public MovieActor(PersonId id, PersonName name) : base(id, name)
    {
    }
}