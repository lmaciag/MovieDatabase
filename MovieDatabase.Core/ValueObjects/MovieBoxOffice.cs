using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieBoxOffice
{
    public decimal Value { get; }

    public MovieBoxOffice(decimal value)
    {
        if (value <= decimal.Zero)
            throw new InvalidMovieBoxOfficeException(value);

        Value = value;
    }

    public static implicit operator decimal(MovieBoxOffice movieBoxOffice) => movieBoxOffice.Value;

    public static implicit operator MovieBoxOffice(decimal value) => new(value);
}