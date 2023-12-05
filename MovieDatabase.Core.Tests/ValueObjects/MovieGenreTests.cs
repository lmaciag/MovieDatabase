using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class MovieGenreTests
{
    [TestCase(MovieGenreEnum.Action)]
    [TestCase(MovieGenreEnum.Crime)]
    [TestCase(MovieGenreEnum.Comedy)]
    [TestCase(MovieGenreEnum.Drama)]
    [TestCase(MovieGenreEnum.Horror)]
    [TestCase(MovieGenreEnum.SciFi)]
    [TestCase(MovieGenreEnum.Fantasy)]
    [TestCase(MovieGenreEnum.War)]
    public void ProperValuesShouldCreateMovieGenre(MovieGenreEnum genre)
    {
        var movieGenre= new MovieGenre(genre);
        
        movieGenre.Value.ShouldBe(genre);
    }
    
    [TestCase(MovieGenreEnum.None)]
    [TestCase(0)]
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(-1)]
    public void OutOfScopeOrZeroValuesShouldThrowInvalidMovieGenreException(MovieGenreEnum genre)
    {
        Should.Throw<InvalidMovieGenreException>(() => new MovieGenre(genre));
    }
}