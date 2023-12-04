using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieTitle
{
    public string Value { get; }

    public MovieTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidMovieTitleException();

        Value = value;
    }

    public static implicit operator string(MovieTitle movieTitle) => movieTitle.Value;

    public static implicit operator MovieTitle(string value) => new(value);
}