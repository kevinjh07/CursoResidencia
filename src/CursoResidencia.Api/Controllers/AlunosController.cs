using CursoResidencia.Application.CreateAluno;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IMediator _mediator;
    private IAlunoService _alunoService;

    public AlunosController(IMediator mediator, IAlunoService alunoService)
    {
        _mediator = mediator;
        _alunoService = alunoService;
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
        var aluno = _alunoService.GetById(id);
        if (aluno == null)
            return NotFound();

        return Ok(aluno);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Aluno>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        var alunos = _alunoService.GetAll();
        if (!alunos.Any())
            return NoContent();

        return Ok(alunos);
    }
}
