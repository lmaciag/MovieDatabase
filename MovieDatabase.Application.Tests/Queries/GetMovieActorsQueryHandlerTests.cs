using Moq;
using MovieDatabase.Application.Queries;
using MovieDatabase.Core.Repositories;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Application.Tests.Queries;

[TestFixture]
public class GetMovieActorsQueryHandlerTests
{
    private readonly Mock<IMovieActorRepository> _movieActorRepository;

    public GetMovieActorsQueryHandlerTests()
    {
        _movieActorRepository = MovieTestHelpers.PrepareMovieActorRepository();
    }

    [Test]
    public async Task GetMovieActorsQueryHandlerShouldReturnCorrectCount()
    {
        var actorsQuery = new GetMovieActorsQuery();
        var handler = new GetMovieActorsQueryHandler(_movieActorRepository.Object);

        var result = await handler.Handle(actorsQuery, CancellationToken.None);
        
        result.Count().ShouldBe(2);
    }
}