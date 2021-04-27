using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;
using BC = BCrypt.Net.BCrypt;

namespace KiproshBirthdayCelebration.BuisnessLogic
{
    public class AuthenticateService : IAuthenticateService
    {
        private IConfiguration _config;
        private readonly AppDbContext _context;
        public AuthenticateService(
            IConfiguration config,
            AppDbContext context)
        {
            _config = config;
            _context = context;
        }

        public Associate AuthenticateUser(string userName, string pwd)
        {
            //$2a$11$s2zIFxyIzlv/YCBgPZRKHeIp8BgpaGmoJ7LDoibQxruR1Fz4i9SFe (Kiprosh@123)
            var account = _context.Associates.SingleOrDefault(x => x.UserName == userName);
            if (account != null && BC.Verify(pwd, account.Password))
            {
                return new Associate()
                {
                    Id = account.Id,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Role = account.Role
                };
            }
            else
            {
                return null;
            }
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
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
