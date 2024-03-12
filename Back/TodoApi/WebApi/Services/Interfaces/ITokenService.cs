using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateAccessToken(User user, UserRole role);

        public Task<string> GenerateRefreshToken();
    }
}
