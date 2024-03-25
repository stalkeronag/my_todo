using WebApi.Data;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class RefreshTokenSessionBuilderService : IRefreshTokenSessionBuilderService
    {
        private FingerPrint FingerPrint { get; set; }

        private RefreshToken RefreshToken { get; set; }

        private readonly AppDbContext context;

        public RefreshTokenSessionBuilderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddFingerPrint(FingerPrint fingerPrint)
        {
            FingerPrint = fingerPrint;
        }

        public void AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken = refreshToken;
        }

        public async Task Build(RefreshTokenSession refreshTokenSession)
        {
            if (RefreshToken == null)
            {
                throw new ArgumentNullException(nameof(RefreshToken));
            }

            if (FingerPrint == null)
            {
                throw new ArgumentNullException(nameof(FingerPrint));
            }

            refreshTokenSession.refreshTokens.Add(RefreshToken);
            refreshTokenSession.Fingerprint.Add(FingerPrint);

            context.refreshTokenFingerprints.Add(new RefreshTokenFingerprint()
            {
                RefreshToken = RefreshToken,
                HashFingerPrint = FingerPrint.Hash
            });

            await context.SaveChangesAsync();
        }
    }
}
