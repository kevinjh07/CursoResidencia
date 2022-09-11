﻿using CursoResidencia.Application.CreateCurso;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Models;
using CursoResidencia.Domain.Repository;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class CursosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICursoRepository _cursoRepository;

    public CursosController(IMediator mediator, ICursoRepository cursoRepository)
    {
        _mediator = mediator;
        _cursoRepository = cursoRepository;
    }

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

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Curso>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public IActionResult Get()
    {
        var cursos = _cursoRepository.GetAll();
        if (!cursos.Any())
        {
            return NoContent();
        }

        return Ok(cursos);
    }
}