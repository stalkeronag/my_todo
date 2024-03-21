using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : IdentityDbContext<User, UserRole, string>
    {
        public DbSet<RefreshToken> refreshTokens { get; set; }

        public DbSet<RefreshTokenSession> refreshTokenSessions { get; set; }

        public DbSet<FingerPrint> fingerPrints { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            ApplyMigrations(this);
        }

        public void ApplyMigrations(AppDbContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
