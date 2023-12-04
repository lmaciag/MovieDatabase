using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieId
{
    public Guid Value { get; }

    public MovieId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidMovieIdException(value);

        Value = value;
    }

    public static implicit operator Guid(MovieId movieId) => movieId.Value;

    public static implicit operator MovieId(Guid value) => new(value);

}