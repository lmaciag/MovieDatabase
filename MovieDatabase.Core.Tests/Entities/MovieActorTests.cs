using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Core.Tests.Entities;

[TestFixture]
public class MovieActorTests
{
    [TestCase("3f2504e0-4f89-11d3-9a0c-0305e82c3301", "Leonardo", "DiCaprio")]
    [TestCase("e3f7c6f0-55b6-4b1a-aeed-0c9a042f5ddb", "Meryl", "Streep")]
    [TestCase("7b52009b-64fd-40b7-ae30-fa4e385fecc1", "Tom", "Hanks")]
    [TestCase("bb50eda8-e3cf-4c4a-9f09-dcddb1f926a3", "Kate", "Winslet")]
    [TestCase("cd2df99f-a807-4b04-882d-8dae0efe11d3", "Brad", "Pitt")]
    [TestCase("d1b0e5b2-1ee6-4b5b-8cbf-5178b5f60f0e", "Angelina", "Jolie")]
    [TestCase("f2d8d1ee-8f9d-4b42-a14b-5b1b9d4ff461", "Denzel", "Washington")]
    [TestCase("9c0f7b9d-55e5-4b20-a44b-37f6b78f7c20", "Natalie", "Portman")]
    [TestCase("4e074085-9eea-4d41-82e5-22b8903f8332", "Morgan", "Freeman")]
    [TestCase("a3c1153a-378a-400e-ae05-7f693ed3f80d", "Charlize", "Theron")]
    [TestCase("5cb25040-1c39-4cdd-8c6a-657e464d033f", "Johnny", "Depp")]
    [TestCase("a4b8c2bb-93e0-42c9-aef7-51e5f64c1fa5", "Nicole", "Kidman")]
    [TestCase("c955d2f8-c5b8-4d76-8a88-f8ce890d7d7c", "Hugh", "Jackman")]
    [TestCase("6b2b8ab4-43a2-4ff3-9053-213571e2f5ea", "Sandra", "Bullock")]
    [TestCase("e3b0c442-98fc-4c19-a1f3-5e537c08b5fd", "Robert", "Downey Jr.")]
    public void ProperValuesShouldCreateMovieActor(string id, string firstName, string lastName)
    {
        var parsedGuid = Guid.Parse(id);
        var actor = new MovieActor(parsedGuid, firstName, lastName);
        
        actor.Id.Value.ShouldBe(parsedGuid);
        actor.FirstName.Value.ShouldBe(firstName);
        actor.LastName.Value.ShouldBe(lastName);
    }

    [Test]
    public void IncorrectIdShouldThrowInvalidPersonIdException()
    {
        Should.Throw<InvalidPersonIdException>(() => new MovieActor(Guid.Empty, "Leonardo", "DiCaprio"));
    }

    [Test]
    public void IncorrectFirstNameShouldThrowInvalidPersonNameException()
    {
        Should.Throw<InvalidPersonNameException>(() => new MovieActor(Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), string.Empty, "DiCaprio"));
    }

    [Test]
    public void IncorrectLastNameShouldThrowInvalidPersonNameException()
    {
        Should.Throw<InvalidPersonNameException>(() => new MovieActor(Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"), "Leonardo", string.Empty));
    }
}