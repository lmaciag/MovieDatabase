using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record PersonName
{
    public string Value { get; }

    public PersonName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidPersonNameException();

        Value = value;
    }

    public static implicit operator string(PersonName personName) => personName.Value;

    public static implicit operator PersonName(string value) => new(value);
}