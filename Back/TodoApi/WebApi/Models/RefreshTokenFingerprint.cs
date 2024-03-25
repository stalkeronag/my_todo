using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class RefreshTokenFingerprint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public RefreshToken RefreshToken { get; set; }

        
        public string HashFingerPrint { get; set; }

    }
}
