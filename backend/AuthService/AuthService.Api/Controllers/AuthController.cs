using AuthServce.Application.JWT;
using AuthService.Api.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IValidator<RegisterRequest> registerRequestValidator, IConnectionMultiplexer muxer, IJwtProvider jwtProvider) : ControllerBase
    {
        private readonly IValidator<RegisterRequest> _registerRequestValidator = registerRequestValidator;
        private readonly IDatabase _redis = muxer.GetDatabase();
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            #region Validation

            var result = _registerRequestValidator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }

            #endregion
            var guid = Guid.NewGuid();
            var jwt = _jwtProvider.GenerateToken(guid);

            //_redis.StringSet("myKey", "myValue", TimeSpan.FromSeconds(5));
            //Thread.Sleep(10000);
            //string value = _redis.StringGet("myKey");

            return Ok(new {guid, jwt });
        }


    }
}
