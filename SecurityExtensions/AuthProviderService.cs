using KiproshBirthdayCelebration.SecurityExtensions.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;

namespace KiproshBirthdayCelebration.SecurityExtensions
{
    public class AuthProviderService : IAuthProviderService
    {
        private IConfiguration _config;
        public AuthProviderService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJSONWebToken(Associate request)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, request.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, request.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                            _config["Jwt:Issuer"],
              claims.ToArray(),
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
