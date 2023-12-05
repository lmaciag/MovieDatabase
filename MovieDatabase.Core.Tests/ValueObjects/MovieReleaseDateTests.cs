using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class MovieReleaseDateTests
{
    [TestCase("1994-07-06")] // Forrest Gump
    [TestCase("1994-09-23")] // The Shawshank Redemption
    [TestCase("1972-03-24")] // The Godfather
    [TestCase("2008-07-18")] // The Dark Knight
    [TestCase("1994-10-14")] // Pulp Fiction
    [TestCase("1993-11-30")] // Schindler's List
    [TestCase("1957-04-10")] // 12 Angry Men
    [TestCase("2003-12-17")] // The Lord of the Rings: The Return of the King
    [TestCase("1999-10-15")] // Fight Club
    [TestCase("1980-05-21")] // Star Wars: Episode V - The Empire Strikes Back
    [TestCase("2001-12-19")] // The Lord of the Rings: The Fellowship of the Ring
    [TestCase("2010-07-16")] // Inception
    [TestCase("1990-09-19")] // Goodfellas
    [TestCase("1975-11-19")] // One Flew Over the Cuckoo's Nest
    [TestCase("1999-03-31")] // The Matrix
    [TestCase("1954-04-26")] // Seven Samurai
    [TestCase("2002-08-30")] // City of God
    [TestCase("1995-09-22")] // Se7en
    [TestCase("1991-02-14")] // The Silence of the Lambs
    [TestCase("1946-12-20")] // It's a Wonderful Life
    [TestCase("1997-12-20")] // Life Is Beautiful
    [TestCase("1995-08-16")] // The Usual Suspects
    [TestCase("1994-09-14")] // Léon: The Professional
    [TestCase("2001-07-20")] // Spirited Away
    [TestCase("1998-07-24")] // Saving Private Ryan
    [TestCase("1998-10-30")] // American History X
    [TestCase("2014-11-05")] // Interstellar
    [TestCase("1999-12-10")] // The Green Mile
    [TestCase("2019-05-30")] // Parasite
    [TestCase("2006-10-20")] // The Prestige
    [TestCase("1994-06-15")] // The Lion King
    [TestCase("1985-07-03")] // Back to the Future
    [TestCase("2006-09-26")] // The Departed
    [TestCase("2014-10-15")] // Whiplash
    [TestCase("2000-05-01")] // Gladiator
    [TestCase("2011-11-02")] // The Intouchables
    [TestCase("2002-05-24")] // The Pianist
    [TestCase("1991-07-03")] // Terminator 2: Judgment Day
    [TestCase("1942-11-26")] // Casablanca
    [TestCase("1981-06-12")] // Raiders of the Lost Ark
    [TestCase("1940-10-15")] // The Great Dictator
    [TestCase("1980-05-23")] // The Shining
    [TestCase("1979-08-15")] // Apocalypse Now
    [TestCase("1979-05-25")] // Alien
    [TestCase("1950-08-10")] // Sunset Boulevard
    [TestCase("1964-01-29")] // Dr. Strangelove
    [TestCase("2006-03-23")] // The Lives of Others
    [TestCase("1988-04-16")] // Grave of the Fireflies
    [TestCase("1957-10-25")] // Paths of Glory
    [TestCase("2012-12-25")] // Django Unchained
    public void ProperDatesShouldCreateMovieReleaseDate(string date)
    {
        var parsedDate = DateOnly.Parse(date);
        var movieReleaseDate = new MovieReleaseDate(parsedDate);
        
        movieReleaseDate.Value.ShouldBe(parsedDate);
    }
    
    [TestCase]
    public void MinValueShouldThrowInvalidMovieReleaseDateException()
    {
        Should.Throw<InvalidMovieReleaseDateException>(() => new MovieReleaseDate(DateOnly.MinValue));
    }
    
    [TestCase]
    public void MaxValueShouldThrowInvalidMovieReleaseDateException()
    {
        Should.Throw<InvalidMovieReleaseDateException>(() => new MovieReleaseDate(DateOnly.MaxValue));
    }
}