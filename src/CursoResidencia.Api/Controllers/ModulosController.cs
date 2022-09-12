﻿using CursoResidencia.Application.CreateModulo;
using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[Authorize(Roles = "Administrador")]
[ApiController]
[Route("[controller]")]
public class ModulosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModulosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateModuloResult), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> Post([FromBody] CreateModuloCommand command)
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
    [ProducesResponseType(typeof(Modulo), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Modulo>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NoContent)]
    public IActionResult GetAll()
    {
        return Ok();
    }
}