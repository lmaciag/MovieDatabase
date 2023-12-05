using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.Entities;

[TestFixture]
public class MovieTests
{
    private const string _title = "Titanic";
    private const MovieGenreEnum _genre = MovieGenreEnum.Drama;
    private readonly MovieDirector _director = new (Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3"), "James", "Cameron");
    private readonly DateOnly _releaseDate = new (1997, 12, 19);
    private const decimal _boxOffice = 350000000.00m;
    private const int _length = 195;
    private readonly MovieActor _firstActor = new (Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3"), "Leonardo", "DiCaprio");
    private readonly MovieActor _secondActor = new (Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3"), "Kate", "Winslet");
    
    [Test]
    public void ProperValuesShouldCreateMovie()
    {
        var movie = new Movie(_title, _genre, _director, _releaseDate, _boxOffice, _length, new List<MovieActor> {_firstActor, _secondActor});
        
        movie.Id.Value.ShouldNotBe(Guid.Empty);
        movie.Genre.Value.ShouldBe(_genre);
        movie.Director.Id.ShouldBe(_director.Id);
        movie.ReleaseDate.Value.ShouldBe(_releaseDate);
        movie.BoxOffice.Value.ShouldBe(_boxOffice);
        movie.Length.Value.ShouldBe(_length);
        movie.Actors.Count.ShouldBe(2);
    }

    [Test]
    public void IncorrectTitleShouldThrowInvalidMovieTitleException()
    {
        Should.Throw<InvalidMovieTitleException>(() => new Movie(string.Empty, _genre, _director, _releaseDate, _boxOffice, _length, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void IncorrectGenreShouldThrowInvalidMovieGenreException()
    {
        Should.Throw<InvalidMovieGenreException>(() => new Movie(_title, MovieGenreEnum.None, _director, _releaseDate, _boxOffice, _length, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void EmptyDirectorShouldThrowEmptyMovieDirectorException()
    {
        Should.Throw<EmptyMovieDirectorException>(() => new Movie(_title, _genre, null!, _releaseDate, _boxOffice, _length, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void IncorrectReleaseDateShouldThrowInvalidMovieReleaseDateException()
    {
        Should.Throw<InvalidMovieReleaseDateException>(() => new Movie(_title, _genre, _director, DateOnly.MinValue, _boxOffice, _length, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void IncorrectBoxOfficeShouldThrowInvalidMovieBoxOfficeException()
    {
        Should.Throw<InvalidMovieBoxOfficeException>(() => new Movie(_title, _genre, _director, _releaseDate, 0, _length, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void IncorrectLengthShouldThrowInvalidMovieLengthException()
    {
        Should.Throw<InvalidMovieLengthException>(() => new Movie(_title, _genre, _director, _releaseDate, _boxOffice, 0, new List<MovieActor> {_firstActor, _secondActor}));
    }

    [Test]
    public void EmptyActorsShouldThrowInsufficientMovieActorsException()
    {
        Should.Throw<InsufficientMovieActorsException>(() => new Movie(_title, _genre, _director, _releaseDate, _boxOffice, _length, null!));
    }

    [Test]
    public void OneActorShouldThrowInsufficientMovieActorsException()
    {
        Should.Throw<InsufficientMovieActorsException>(() => new Movie(_title, _genre, _director, _releaseDate, _boxOffice, _length, new List<MovieActor> {_firstActor}));
    }
}