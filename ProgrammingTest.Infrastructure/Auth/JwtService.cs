using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Infrastructure.Auth
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;
        private readonly IUserRepository _userRepository;

        public JwtService(IConfiguration config, IUserRepository userRepository)
        {
            _secret = config["Jwt:Key"]!;
            _userRepository = userRepository;
        }

        public async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var roles = await _userRepository.GetUserRolesAsync(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
