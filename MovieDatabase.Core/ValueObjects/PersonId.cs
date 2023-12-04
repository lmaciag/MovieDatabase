using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record PersonId
{
    public Guid Value { get; }

    public PersonId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidPersonIdException(value);

        Value = value;
    }

    public static implicit operator Guid(PersonId personId) => personId.Value;

    public static implicit operator PersonId(Guid value) => new(value);

}