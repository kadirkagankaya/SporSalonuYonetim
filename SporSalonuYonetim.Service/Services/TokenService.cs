using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;
using SporSalonuYonetim.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SporSalonuYonetim.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["TokenOptions:AccessTokenExpiration"]));

            var token = new JwtSecurityToken(
                _configuration["TokenOptions:Issuer"],
                _configuration["TokenOptions:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expires
            };
        }
    }
}
