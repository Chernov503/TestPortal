using AuthService.Api.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<RegisterRequest> _registerRequestValidator;

        public AuthController(IValidator<RegisterRequest> registerRequestValidator)
        {
            _registerRequestValidator = registerRequestValidator;
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = _registerRequestValidator.Validate(request);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => x.ErrorMessage));
            }

            return Ok();
        }
    }
}
