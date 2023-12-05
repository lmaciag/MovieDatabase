using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.ValueObjects;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.ValueObjects;

[TestFixture]
public class MovieTitleTests
{
    [TestCase("Forrest Gump")]
    [TestCase("The Shawshank Redemption")]
    [TestCase("The Godfather")]
    [TestCase("The Dark Knight")]
    [TestCase("Pulp Fiction")]
    [TestCase("Schindler's List")]
    [TestCase("12 Angry Men")]
    [TestCase("The Lord of the Rings: The Return of the King")]
    [TestCase("Fight Club")]
    [TestCase("Star Wars: Episode V - The Empire Strikes Back")]
    [TestCase("The Lord of the Rings: The Fellowship of the Ring")]
    [TestCase("Inception")]
    [TestCase("Goodfellas")]
    [TestCase("One Flew Over the Cuckoo's Nest")]
    [TestCase("The Matrix")]
    [TestCase("Seven Samurai")]
    [TestCase("City of God")]
    [TestCase("Se7en")]
    [TestCase("The Silence of the Lambs")]
    [TestCase("It's a Wonderful Life")]
    [TestCase("Life Is Beautiful")]
    [TestCase("The Usual Suspects")]
    [TestCase("Léon: The Professional")]
    [TestCase("Spirited Away")]
    [TestCase("Saving Private Ryan")]
    [TestCase("American History X")]
    [TestCase("Interstellar")]
    [TestCase("The Green Mile")]
    [TestCase("Parasite")]
    [TestCase("The Prestige")]
    [TestCase("The Lion King")]
    [TestCase("Back to the Future")]
    [TestCase("The Departed")]
    [TestCase("Whiplash")]
    [TestCase("Gladiator")]
    [TestCase("The Intouchables")]
    [TestCase("The Pianist")]
    [TestCase("Terminator 2: Judgment Day")]
    [TestCase("Casablanca")]
    [TestCase("Raiders of the Lost Ark")]
    [TestCase("The Great Dictator")]
    [TestCase("The Shining")]
    [TestCase("Apocalypse Now")]
    [TestCase("Alien")]
    [TestCase("Sunset Boulevard")]
    [TestCase("Dr. Strangelove")]
    [TestCase("The Lives of Others")]
    [TestCase("Grave of the Fireflies")]
    [TestCase("Paths of Glory")]
    [TestCase("Django Unchained")]
    public void ProperTitlesShouldCreateMovieTitle(string title)
    {
        var movieTitle = new MovieTitle(title);
        
        movieTitle.Value.ShouldBe(title);
    }
    
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void EmptyValuesShouldThrowInvalidMovieTitleException(string name)
    {
        Should.Throw<InvalidMovieTitleException>(() => new MovieTitle(name));
    }
}