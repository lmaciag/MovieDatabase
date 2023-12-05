using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Dtos;
using MovieDatabase.Application.Queries;

namespace MovieDatabase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DirectorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DirectorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MoviePersonDto>>> GetDirectors()
    {
        var directors = await _mediator.Send(new GetDirectorsQuery());
        return Ok(directors);
    }
}