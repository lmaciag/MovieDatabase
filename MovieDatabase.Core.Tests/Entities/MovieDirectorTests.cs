using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.Entities;

[TestFixture]
public class MovieDirectorTests
{
    [TestCase("cd2df99f-a807-4b04-882d-8dae0efe11d3", "Steven", "Spielberg")]
    [TestCase("e3b0c442-98fc-4c19-a1f3-5e537c08b5fd", "Martin", "Scorsese")]
    [TestCase("9c0f7b9d-55e5-4b20-a44b-37f6b78f7c20", "Christopher", "Nolan")]
    [TestCase("6b2b8ab4-43a2-4ff3-9053-213571e2f5ea", "Quentin", "Tarantino")]
    [TestCase("4e074085-9eea-4d41-82e5-22b8903f8332", "Alfred", "Hitchcock")]
    [TestCase("a3c1153a-378a-400e-ae05-7f693ed3f80d", "Francis", "Coppola")]
    [TestCase("5cb25040-1c39-4cdd-8c6a-657e464d033f", "Ridley", "Scott")]
    [TestCase("a4b8c2bb-93e0-42c9-aef7-51e5f64c1fa5", "Stanley", "Kubrick")]
    [TestCase("c955d2f8-c5b8-4d76-8a88-f8ce890d7d7c", "James", "Cameron")]
    [TestCase("d1b0e5b2-1ee6-4b5b-8cbf-5178b5f60f0e", "George", "Lucas")]
    [TestCase("f2d8d1ee-8f9d-4b42-a14b-5b1b9d4ff461", "Tim", "Burton")]
    [TestCase("3f2504e0-4f89-11d3-9a0c-0305e82c3301", "Peter", "Jackson")]
    [TestCase("7b52009b-64fd-40b7-ae30-fa4e385fecc1", "Guillermo", "del Toro")]
    [TestCase("e3f7c6f0-55b6-4b1a-aeed-0c9a042f5ddb", "Ron", "Howard")]
    [TestCase("bb50eda8-e3cf-4c4a-9f09-dcddb1f926a3", "Clint", "Eastwood")]
    public void ProperValuesShouldCreateMovieDirector(string id, string firstName, string lastName)
    {
        var parsedGuid = Guid.Parse(id);
        var director = new MovieDirector(parsedGuid, firstName, lastName);
        
        director.Id.Value.ShouldBe(parsedGuid);
        director.FirstName.Value.ShouldBe(firstName);
        director.LastName.Value.ShouldBe(lastName);
    }

    [Test]
    public void IncorrectIdShouldThrowInvalidPersonIdException()
    {
        Should.Throw<InvalidPersonIdException>(() => new MovieDirector(Guid.Empty, "Steven", "Spielberg"));
    }

    [Test]
    public void IncorrectFirstNameShouldThrowInvalidPersonNameException()
    {
        Should.Throw<InvalidPersonNameException>(() => new MovieDirector(Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3"), string.Empty, "Spielberg"));
    }

    [Test]
    public void IncorrectLastNameShouldThrowInvalidPersonNameException()
    {
        Should.Throw<InvalidPersonNameException>(() => new MovieDirector(Guid.Parse("cd2df99f-a807-4b04-882d-8dae0efe11d3"), "Steven", string.Empty));
    }
}