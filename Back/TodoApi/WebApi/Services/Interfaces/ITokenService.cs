using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(User user, UserRole role);

        public string GenerateRefreshToken(User user);
    }
}
