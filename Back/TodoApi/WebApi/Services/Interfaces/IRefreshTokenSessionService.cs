using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IRefreshTokenSessionService
    {
        public Task CreateSession(string fingerPrint, User user);

        public Task DeleteSessionById(string id);
 
    }
}
