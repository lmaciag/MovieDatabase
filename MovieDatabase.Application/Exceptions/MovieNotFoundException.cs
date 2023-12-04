using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Application.Exceptions;

public sealed class MovieNotFoundException : BaseException
{
    public MovieId MovieId { get; private set; }
    
    public MovieNotFoundException(MovieId movieId) : base($"Movie with given id: '{movieId}' was not found.")
    {
        MovieId = movieId;
    }
}