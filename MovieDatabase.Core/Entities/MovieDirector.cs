using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Core.Entities;

public sealed class MovieDirector : Person
{
    public MovieDirector(PersonId id, PersonName firstName, PersonName lastName) : base(id, firstName, lastName)
    {
    }
}