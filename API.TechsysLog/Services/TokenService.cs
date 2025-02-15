using API.TechsysLog.Domain;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.TechsysLog.Services
{
    public class TokenService
    {
        public static object GenerateToken(User user)
        {
            IDictionary data = Environment.GetEnvironmentVariables();

            // Display the details with key and value 
            foreach (DictionaryEntry i in data)
            {
                Console.WriteLine("{0}:{1}", i.Key, i.Value);
            }

            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("ASPNETCORE_AUTO_RELOAD_WS_KEY"));

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim("UserId",user.Id.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
