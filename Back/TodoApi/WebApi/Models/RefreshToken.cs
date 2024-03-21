using System.Security;

namespace WebApi.Models
{
    public class RefreshToken
    {
        public string Token { get; set; }

        public string Id { get; set; }

        public DateTime Expires { get; set; }

        public DateTime Created { get ; set; } 

    }
}
