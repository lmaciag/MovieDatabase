using Moq;
using MovieDatabase.Application.Queries;
using MovieDatabase.Core.Repositories;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Application.Tests.Queries;

[TestFixture]
public class GetActorsQueryHandlerTests
{
    private readonly Mock<IActorRepository> _actorRepository;

    public GetActorsQueryHandlerTests()
    {
        _actorRepository = MovieTestHelpers.PrepareActorRepository();
    }

    [Test]
    public async Task GetActorsQueryHandlerShouldReturnCorrectCount()
    {
        var actorsQuery = new GetActorsQuery();
        var handler = new GetActorsQueryHandler(_actorRepository.Object);

        var result = await handler.Handle(actorsQuery, CancellationToken.None);
        
        result.Count().ShouldBe(2);
    }
}