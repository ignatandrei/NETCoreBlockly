using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TestBlocklyHtml.Authorization
{
    public class AuthorizationToken
    {

        private readonly IConfiguration configuration;

        public AuthorizationToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateFrom(string secretCode)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(configuration["ApplicationSecret"]);
            var key = Encoding.ASCII.GetBytes("mySecretKeyThatShouldBeStoredInConfiguration");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Sid, secretCode)
                }),
                Expires = DateTime.Today.AddYears(100),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
