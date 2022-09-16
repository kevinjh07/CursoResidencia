using CursoResidencia.Application.CreateProfessor;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Application.UpdateProfessor;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class ProfessoresController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProfessorService _professorRepository;

    public ProfessoresController(IMediator mediator, IProfessorService professorRepository)
    {
        _mediator = mediator;
        _professorRepository = professorRepository;
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
        var professor = _professorRepository.Get(id);
        if (professor == null)
            return NotFound();

        return Ok(professor);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Professor>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        var professores = _professorRepository.GetAll();
        if (!professores.Any())
            return NoContent();

        return Ok(professores);
    }

    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProfessorCommand command)
    {
        command.Id = id;

        try
        {
            await _mediator.Send(command);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (UnprocessableEntityException e)
        {
            return UnprocessableEntity(new { message = e.Message });
        }
    }
}
