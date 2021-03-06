using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosAPI.Model;

namespace UsuariosAPI.Service
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> user, List<string> roles)
        {
            IList<Claim> direitosUsuario = new List<Claim>()
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                
            };
            foreach (string item in roles)
            {
                direitosUsuario.Add(new Claim("role", item));
            }
            direitosUsuario.ToArray();
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12345678910111213141516171819202122"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
