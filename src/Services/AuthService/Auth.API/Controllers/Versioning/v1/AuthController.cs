using Asp.Versioning;
using Auth.Application.Commands;
using Core.Configuration.APIConfiguration;
using Core.Notifications.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Auth.API.Controllers.Versioning.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class AuthController(INotifier notificador, IMediator mediator) : MainController(notificador)
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CustomResponse(HttpStatusCode.Created, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CustomResponse(HttpStatusCode.OK, result);
        }

    }
}
