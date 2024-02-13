namespace WebApi.Services.Interfaces
{
    public interface ITokenService
    {
        public Task GenerateAccessToken();

        public Task GenerateRefreshToken();
    }
}
