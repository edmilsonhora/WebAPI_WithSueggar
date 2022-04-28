using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi_With_Swagger_Teste0.Models;

namespace WebApi_With_Swagger_Teste0.Services
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, usuario.Role),
                    
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }

        private void NumberGenerator()
        {
            var randonNumeber = new byte[32];

            using (var rgn = RandomNumberGenerator.Create())
            {
                rgn.GetBytes(randonNumeber);
               var r = Convert.ToBase64String(randonNumeber);
            }
        }
    }
}
