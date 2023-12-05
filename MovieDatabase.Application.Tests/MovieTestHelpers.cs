using Moq;
using MovieDatabase.Application.Commands;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Repositories;

namespace MovieDatabase.Application.Tests;

public static class MovieTestHelpers
{
    private static string _movieTitle = "Titanic";
    private static MovieGenreEnum _movieGenre = MovieGenreEnum.Drama;
    private static Guid _movieDirectorId = Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3");
    private static DateOnly _movieReleaseDate = new (1997, 12, 19);
    private static decimal _movieBoxOffice = 350000000.00m;
    private static int _movieLength = 195;
    private static Guid _movieFirstActorId = Guid.Parse("43342e12-0ad1-4b14-aab9-d52abb915708");
    private static Guid _movieSecondActorId = Guid.Parse("cfc4d97c-0911-4845-94b2-57569dad246c");

    public static CreateMovieCommand PrepareCreateMovieCommand()
    {
        return new CreateMovieCommand(_movieTitle, _movieGenre, _movieDirectorId, _movieReleaseDate, _movieBoxOffice, _movieLength, new List<Guid> {_movieFirstActorId, _movieSecondActorId});
    }

    public static Mock<IMovieRepository> PrepareMovieRepository()
    {
        var movieRepositoryMock = new Mock<IMovieRepository>();
        return movieRepositoryMock;
    }

    public static Mock<IActorRepository> PrepareActorRepository()
    {
        var actorRepositoryMock = new Mock<IActorRepository>();
        
        actorRepositoryMock.Setup(x => x.GetAsync(CancellationToken.None, It.IsAny<ICollection<Guid>?>()))
            .ReturnsAsync(new List<MovieActor> { new (_movieFirstActorId, "Leo", "DiCaprio"), new (_movieSecondActorId, "Kate", "Winslet")});

        return actorRepositoryMock;
    }

    public static Mock<IDirectorRepository> PrepareDirectorRepository()
    {
        var directorRepositoryMock = new Mock<IDirectorRepository>();
        
        directorRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
            .ReturnsAsync(new MovieDirector(_movieDirectorId, "James", "Cameron"));

        return directorRepositoryMock;
    }
}