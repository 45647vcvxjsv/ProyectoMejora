using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyPymeGames.Core.Entities;

namespace MyPymeGames.API.Services
{
    public class JwtServices
    {
       private readonly IConfiguration _configuration;
         public JwtServices(IConfiguration configuration)
         {
              _configuration = configuration;
         }

         public string GenerateToken (User user)
         {
            var secret = _configuration["JwtSettings:Secret"] ?? throw new ArgumentNullException("Secret Cannot be Null");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var token = new JwtSecurityToken(
                issuer: "MyPymeGames",
                audience: "MyPymeGames",
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationTime"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
         }
    }
}