using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Queries;

namespace MovieDatabase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MoviePersonDto>>> GetActors()
    {
        var actors = await _mediator.Send(new GetActorsQuery());
        return Ok(actors);
    }
}