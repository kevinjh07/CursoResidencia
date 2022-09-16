using CursoResidencia.Application.CreateAluno;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediator _mediator;

    public AlunosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(CreateAlunoResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateAlunoCommand command)
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

    [Authorize(Roles = "Administrador")]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Aluno), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        return NotFound();
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Aluno>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        return NoContent();
    }
}
