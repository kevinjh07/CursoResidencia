using Microsoft.AspNetCore.Authorization;

namespace CursoResidencia.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpPost("login")]
    //[ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.NotFound)]
    //[ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    //[ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.UnprocessableEntity)]
    //public async Task<IActionResult> Login(Login login)
    //{
    //    try
    //    {
    //        var response = await _authService.LoginAsync(login);
    //        return _mediator.Send(response);

    //        var result = await _mediator.Send(response);
    //        return Ok(result);
    //    }
    //    catch (UnprocessableEntityException e)
    //    {
    //        return UnprocessableEntity(new { message = e.Message });
    //    }
    //    catch (NotFoundException)
    //    {
    //        return NotFound();
    //    }
    //}

    //[HttpPost]
    //[Route("refresh")]
    //public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
    //{
    //    try
    //    {
    //        var loginResponse = await _authService.Refresh(request);
    //        return Ok(loginResponse);
    //    }
    //    catch (SecurityTokenException e)
    //    {
    //        return UnprocessableEntity(new { message = e.Message });
    //    }
    //}
}
