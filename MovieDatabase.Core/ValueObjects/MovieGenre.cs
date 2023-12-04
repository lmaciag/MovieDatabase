using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Core.ValueObjects;

public sealed record MovieGenre
{
    public MovieGenreEnum Value { get; }

    public MovieGenre(MovieGenreEnum value)
    {
        if(value is MovieGenreEnum.None or 0 || !Enum.IsDefined(typeof(MovieGenreEnum), value))
            throw new InvalidMovieGenreException(value);

        Value = value;
    }

    public static implicit operator MovieGenreEnum(MovieGenre movieGenre) => movieGenre.Value;

    public static implicit operator MovieGenre(MovieGenreEnum value) => new(value);
}