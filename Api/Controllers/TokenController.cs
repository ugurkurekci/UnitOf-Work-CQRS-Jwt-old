using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.JWT;
using Security.JWT.Services;
using Security.JWT.Services.Handlers;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IMediator _mediator;

    public TokenController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AccessToken([FromBody] User user)
    {
        Tokens tokens = await _mediator.Send(new AccessCommand(user));
        return Ok(tokens);
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken(RefreshRequest refreshRequest)
    {
        Tokens tokens = await _mediator.Send(new RefreshCommand(refreshRequest.user, refreshRequest));
        return Ok(tokens);
    }

}