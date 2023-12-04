using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieReleaseDate
{
    public DateOnly Value { get; }

    public MovieReleaseDate(DateOnly value)
    {
        if (value == DateOnly.MinValue || value == DateOnly.MaxValue)
            throw new InvalidMovieReleaseDateException(value);

        Value = value;
    }

    public static implicit operator DateOnly(MovieReleaseDate movieReleaseDate) => movieReleaseDate.Value;

    public static implicit operator MovieReleaseDate(DateOnly value) => new(value);
}