using AuthService.Api.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<RegisterRequest> _registerRequestValidator;
        private readonly IDatabase _redis;

        public AuthController(IValidator<RegisterRequest> registerRequestValidator, IConnectionMultiplexer muxer)
        {
            _registerRequestValidator = registerRequestValidator;
            _redis = muxer.GetDatabase();
        }

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



            //_redis.StringSet("myKey", "myValue", TimeSpan.FromSeconds(5));
            //Thread.Sleep(10000);
            //string value = _redis.StringGet("myKey");

            return Ok();
        }
    }
}
