using MovieDatabase.Core.Exceptions;

namespace MovieDatabase.Application.Exceptions;

public sealed class MovieNotFoundException : BaseException
{
    public Guid MovieId { get; private set; }
    
    public MovieNotFoundException(Guid movieId) : base($"Movie with given id: '{movieId}' was not found.")
    {
        MovieId = movieId;
    }
}