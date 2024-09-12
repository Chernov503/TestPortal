using AuthServce.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServce.Application.JWT
{
    public class JwtProvider(IConfiguration configuration,
                             IOptions<JwtSettings> jwtSettings) : IJwtProvider
    {
        private readonly IConfiguration _configuration = configuration;
        protected double ExpiresHours = jwtSettings.Value.ExpiresHours;
        protected string SecretKey = jwtSettings.Value.SecretKey;
        public string GenerateToken(Guid userId)
        {
            Claim[] claims = { new(ClaimTypes.NameIdentifier, userId.ToString()) };

            var signingCredentials = new SigningCredentials(
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(ExpiresHours),
                claims: claims);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }

}
