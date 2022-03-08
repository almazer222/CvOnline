using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.API.Helper
{
    public class TokenHelper
    {
        /// <summary>
        /// Methode de création d'un token pour l'authentification
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string CreateToken(string secret, int id)
        {
            //Récupération de la clé
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                       new Claim(ClaimTypes.Name, id.ToString())
                   }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
