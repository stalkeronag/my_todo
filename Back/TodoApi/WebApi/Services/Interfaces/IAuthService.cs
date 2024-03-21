using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<User> GetCurrentUser();
    }
}
