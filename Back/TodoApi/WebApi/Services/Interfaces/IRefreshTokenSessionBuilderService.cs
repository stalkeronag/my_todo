using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IRefreshTokenSessionBuilderService
    {
        public Task Build(RefreshTokenSession refreshTokenSession);

        public void AddRefreshToken(RefreshToken refreshToken);

        public void AddFingerPrint(FingerPrint fingerPrint);
    }
}
