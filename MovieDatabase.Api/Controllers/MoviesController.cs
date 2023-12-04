using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Commands;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Queries;

namespace MovieDatabase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieItemDto>>> GetMovies()
    {
        var movies = await _mediator.Send(new GetMoviesQuery());
        return Ok(movies);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MovieDto>> GetMovie(Guid id)
    {
        var movie = await _mediator.Send(new GetMovieQuery(id));
        return Ok(movie);
    }
    
    [HttpGet("Genres")]
    public async Task<ActionResult<IEnumerable<MovieGenreItemDto>>> GetMovieGenres()
    {
        var genres = await _mediator.Send(new GetMovieGenresQuery());
        return Ok(genres);
    }
    
    [HttpGet("Actors")]
    public async Task<ActionResult<IEnumerable<MoviePersonDto>>> GetMovieActors()
    {
        var actors = await _mediator.Send(new GetMovieActorsQuery());
        return Ok(actors);
    }
    
    [HttpGet("Directors")]
    public async Task<ActionResult<IEnumerable<MoviePersonDto>>> GetMovieDirectors()
    {
        var directors = await _mediator.Send(new GetMovieDirectorsQuery());
        return Ok(directors);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieCommand command)
    {
        var movie = await _mediator.Send(command);
        return Ok(movie);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMovie(Guid id)
    {
        await _mediator.Send(new DeleteMovieCommand(id));
        return NoContent();
    }
}