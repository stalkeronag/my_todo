﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class RefreshTokenSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public List<RefreshToken> refreshTokens { get; set; }

        public List<FingerPrint> Fingerprint { get; set; }

        [Required]
        public User User { get; set; }
    }
}
