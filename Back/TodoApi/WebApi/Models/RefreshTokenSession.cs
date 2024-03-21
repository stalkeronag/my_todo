using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class RefreshTokenSession
    {
        public string Id { get; set; }

        public List<RefreshToken> refreshTokens { get; set; }

        public List<FingerPrint> Fingerprint { get; set; }

        public User User { get; set; }
    }
}
