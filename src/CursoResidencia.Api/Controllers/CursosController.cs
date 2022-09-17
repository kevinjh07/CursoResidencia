using CursoResidencia.Application.CreateCurso;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Application.UpdateCurso;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Models;
using CursoResidencia.Domain.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CursosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICursoService _cursoRepository;

    public CursosController(IMediator mediator, ICursoService cursoRepository)
    {
        _mediator = mediator;
        _cursoRepository = cursoRepository;
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    [ProducesResponseType(typeof(CreateCursoResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateCursoCommand command)
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
    [ProducesResponseType(typeof(Curso), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        try
        {
            var curso = _cursoRepository.GetById(id);

            if (curso == null)
            {
                return NotFound();
            }

            return Ok(curso);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Curso>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        var cursos = _cursoRepository.GetAll();
        if (!cursos.Any())
        {
            return NoContent();
        }

        return Ok(cursos);
    }

    [Authorize(Roles = "Aluno")]
    [HttpGet("disponiveis")]
    [ProducesResponseType(typeof(IEnumerable<CursoDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetDisponiveis()
    {
        var cursos = _cursoRepository.GetDisponiveis();
        if (!cursos.Any())
        {
            return NoContent();
        }

        return Ok(cursos);
    }

    [Authorize(Roles = "Aluno")]
    [HttpGet("{id}/aulas")]
    [ProducesResponseType(typeof(CursoDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetDisponiveis([FromRoute] int id)
    {
        var curso = _cursoRepository.GetAulas(id);
        if (curso == null)
        {
            return NotFound();
        }

        return Ok(curso);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateCursoCommand command)
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
