using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;

namespace MovieDatabase.Application.Exceptions;

public class MovieDirectorNotFoundException : BaseException
{
    public PersonId MovieDirectorId { get; private set; }
    
    public MovieDirectorNotFoundException(PersonId personId) : base($"Movie director with given id: '{personId}' was not found.")
    {
        MovieDirectorId = personId;
    }
}