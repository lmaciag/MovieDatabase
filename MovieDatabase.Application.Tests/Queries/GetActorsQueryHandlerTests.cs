using Moq;
using MovieDatabase.Application.Queries;
using MovieDatabase.Core.Repositories;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Application.Tests.Queries;

[TestFixture]
public class GetActorsQueryHandlerTests
{
    private readonly Mock<IMovieActorRepository> _movieActorRepository;

    public GetActorsQueryHandlerTests()
    {
        _movieActorRepository = MovieTestHelpers.PrepareMovieActorRepository();
    }

    [Test]
    public async Task GetActorsQueryHandlerShouldReturnCorrectCount()
    {
        var actorsQuery = new GetActorsQuery();
        var handler = new GetActorsQueryHandler(_movieActorRepository.Object);

        var result = await handler.Handle(actorsQuery, CancellationToken.None);
        
        result.Count().ShouldBe(2);
    }
}