using Moq;
using MovieDatabase.Application.Commands;
using MovieDatabase.Application.Exceptions;
using MovieDatabase.Core.Entities;
using MovieDatabase.Core.Enums;
using MovieDatabase.Core.Exceptions;
using MovieDatabase.Core.Repositories;
using NUnit.Framework;
using Shouldly;

namespace MovieDatabase.Application.Tests.Commands;

[TestFixture]
public class CreateMovieCommandHandlerTests
{
    private readonly Mock<IMovieRepository> _movieRepository;
    private readonly Mock<IActorRepository> _actorRepository;
    private readonly Mock<IDirectorRepository> _directorRepository;

    public CreateMovieCommandHandlerTests()
    {
        _movieRepository = MovieTestHelpers.PrepareMovieRepository();
        _actorRepository = MovieTestHelpers.PrepareActorRepository();
        _directorRepository = MovieTestHelpers.PrepareDirectorRepository();
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerShouldCreateNewMovieAndSuccessfullyStore()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand();
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        var result = await handler.Handle(movieCommand, CancellationToken.None);
        
        result.Id.ShouldNotBe(Guid.Empty);
        result.Title.ShouldBe(movieCommand.Title);
        result.Genre.ShouldBe(movieCommand.Genre);
        result.DirectorId.ShouldBe(movieCommand.DirectorId);
        result.ReleaseDate.ShouldBe(movieCommand.ReleaseDate);
        result.BoxOffice.ShouldBe(movieCommand.BoxOffice);
        result.Length.ShouldBe(movieCommand.Length);
        result.ActorsIds.Count().ShouldBe(movieCommand.ActorsIds.Count);
        _movieRepository.Verify(x => x.AddAsync(It.IsAny<Movie>(), CancellationToken.None), Times.Once);
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithEmptyTitleShouldThrowInvalidMovieTitleException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { Title = string.Empty };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InvalidMovieTitleException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithIncorrectGenreShouldThrowInvalidMovieGenreException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { Genre = MovieGenreEnum.None };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InvalidMovieGenreException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithWrongDirectorIdShouldThrowMovieDirectorNotFoundException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { DirectorId = Guid.Parse("b2241753-983a-461e-9083-56a4dd7b4bc5") };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, new Mock<IDirectorRepository>().Object);
        
        await Should.ThrowAsync<MovieDirectorNotFoundException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithIncorrectReleaseDateShouldThrowInvalidMovieReleaseDateException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { ReleaseDate = DateOnly.MinValue };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InvalidMovieReleaseDateException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithIncorrectBoxOfficeShouldThrowInvalidMovieBoxOfficeException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { BoxOffice = 0 };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InvalidMovieBoxOfficeException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithIncorrectLengthShouldThrowInvalidMovieLengthException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { Length = 0 };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, _actorRepository.Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InvalidMovieLengthException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
    
    [Test]
    public async Task CreateMovieCommandHandlerWithInsufficientActorsShouldThrowInsufficientMovieActorsException()
    {
        var movieCommand = MovieTestHelpers.PrepareCreateMovieCommand() with { ActorsIds = new List<Guid>() };
        var handler = new CreateMovieCommandHandler(_movieRepository.Object, new Mock<IActorRepository>().Object, _directorRepository.Object);
        
        await Should.ThrowAsync<InsufficientMovieActorsException>(() => handler.Handle(movieCommand, CancellationToken.None));
    }
}