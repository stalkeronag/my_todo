using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class RefreshTokenService : IRefreshTokenSessionService
    {
        private readonly AppDbContext context;

        public RefreshTokenService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteSessionById(string id)
        {
            context.refreshTokenSessions.Remove(context.refreshTokenSessions.Where(session => session.Id == id).FirstOrDefault());
            await context.SaveChangesAsync();
        }

        public async Task<RefreshTokenSession> GetExistSessionOrCreate(User user)
        {
            if (!SessionExist(user))
            {
                var newRefreshSession = new RefreshTokenSession()
                {
                    User = user,
                    Fingerprint = new List<FingerPrint>(),
                    refreshTokens = new List<RefreshToken>()
                };
                context.refreshTokenSessions.Add(newRefreshSession);
                return newRefreshSession;
            }
            var session =  context.refreshTokenSessions.Where(session => session.User.Id == user.Id).FirstOrDefault();
            context.refreshTokens.Where(token => token.RefreshTokenSession.Id == session.Id).Load();
            context.fingerPrints.Where(fingerprint => fingerprint.RefreshTokenSession.Id == session.Id).Load();
            return session;
        }


        public bool SessionExist(User user)
        {
            int isSessionExist = context.refreshTokenSessions.Where(session => session.User.Id == user.Id).Count();

            if (isSessionExist == 1)
                return true;
            else
                return false;
        }
    }
}
