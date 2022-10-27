using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.JWT;
using Security.JWT.Services;
using Security.JWT.Services.Abstraction;
using Security.JWT.Services.Handlers;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenGetService _tokenGetService;

    public TokenController(IMediator mediator, ITokenGetService tokenGetService)
    {
        _mediator = mediator;
        _tokenGetService = tokenGetService;
    }

    [HttpPost("AccessToken")]
    public async Task<IActionResult> AccessToken([FromBody] User user)
    {
        Tokens tokens = await _mediator.Send(new AccessCommand(user));
        return Ok(tokens);
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody]RefreshRequest refreshRequest)
    {
        

        Tokens tokens = await _mediator.Send(new RefreshCommand( refreshRequest));
        return Ok(tokens);
    }

}