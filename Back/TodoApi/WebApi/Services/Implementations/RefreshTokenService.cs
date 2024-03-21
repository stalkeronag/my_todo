using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class RefreshTokenService : IRefreshTokenSessionService
    {
        public Task CreateSession(string fingerPrint, User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSessionById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
