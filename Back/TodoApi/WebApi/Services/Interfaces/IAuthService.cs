namespace WebApi.Services.Interfaces
{
    public interface IAuthService
    {
        public Task SignIn();

        public Task SignOut();
    }
}
