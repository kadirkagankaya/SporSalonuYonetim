using System;

namespace SporSalonuYonetim.Core.DTOs
{
    public class TokenDto
    {
        public required string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
