using AuthServce.Application.Commands;
using AuthServce.Application.Interfaces;
using AuthService.Contracts.Requests;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IValidator<RegisterRequest> registerRequestValidator,
                                IConnectionMultiplexer muxer,
                                IJwtProvider jwtProvider,
                                IMediator mediator) : ControllerBase
    {
        private readonly IValidator<RegisterRequest> _registerRequestValidator = registerRequestValidator;
        private readonly IDatabase _redis = muxer.GetDatabase();
        private readonly IJwtProvider _jwtProvider = jwtProvider;
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request, CancellationToken ct)
        {
            var result = _registerRequestValidator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }

            var registerResult = await _mediator.Send(new RegisterCommand(request), ct);
            if (!registerResult.IsSuccess())
            {
                return BadRequest(registerResult.Error.Message);
            }

            var jwtToken = registerResult.Value;
            return Ok(jwtToken);
        }


    }
}
