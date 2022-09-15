using CursoResidencia.Application.CreateAula;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class AulasController : ControllerBase
{
    private readonly IMediator _mediator;

    public AulasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateAulaResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateAulaCommand command)
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
    [ProducesResponseType(typeof(Aula), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        return NotFound();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Aula>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        return NoContent();
    }

    //[HttpPut("{id}")]
    //[ProducesResponseType((int)HttpStatusCode.NoContent)]
    //[ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    //public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateAulaCommand command)
    //{
    //    command.Id = id;

    //    try
    //    {
    //        await _mediator.Send(command);
    //        return NoContent();
    //    }
    //    catch (NotFoundException)
    //    {
    //        return NotFound();
    //    }
    //    catch (UnprocessableEntityException e)
    //    {
    //        return UnprocessableEntity(new { message = e.Message });
    //    }
    //}
}
