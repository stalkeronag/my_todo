using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> GenerateAccessToken(User user, UserRole role)
        {
            var date = DateTime.Now;
            var userClaims = new List<Claim>();
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Name, user.UserName));
            userClaims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            var jwt = new JwtSecurityToken(
                issuer: configuration["Jwt:ValidIssuer"],
                audience: configuration["Jwt:ValidAudience"],
                claims: userClaims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256)
                );

            return Task<string>.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        public Task<string> GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }
    }
}
