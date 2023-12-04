using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieLength
{
    public int Value { get; }

    public MovieLength(int value)
    {
        if (value <= default(int))
            throw new InvalidMovieLengthException(value);

        Value = value;
    }

    public static implicit operator int(MovieLength movieLength) => movieLength.Value;

    public static implicit operator MovieLength(int value) => new(value);
}