using CursoResidencia.Application.CreateProfessor;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfessoresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateProfessorResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateProfessorCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        catch (UnprocessableEntityException e)
        {
            return UnprocessableEntity(new { message = e.Message });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Professor), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        return Ok();
    }
}
