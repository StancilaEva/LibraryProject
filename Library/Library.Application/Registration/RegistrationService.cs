using Library.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Library.Application.JwtTokenGeneration
{
    public class RegistrationService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public static string GenerateJwtToken(Client client)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("643A60B964080FBAE64AD75F7B7C19D5"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim("UserId",client.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,client.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, client.Username),
                new Claim(JwtRegisteredClaimNames.Email, client.Email)
            };
            var token = new JwtSecurityToken("Library",
                         "SwaggerUI",
                         claims,
                         expires: DateTime.Now.AddMinutes(60),
                         signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<bool> CheckIfUserAlreadyExists(string email)
        {
            var userByEmail = await _userManager.FindByEmailAsync(email);
            if (userByEmail == null)
                return false;
            else
                return true;
        }

        public async Task<bool> CheckUserPassword(string email, string password)
        {
            var identity = await _userManager.FindByEmailAsync(email);
            var existingUser = await _userManager.CheckPasswordAsync(identity, password);
            return existingUser;
        }

        public async Task<string> GetProfileId(string email)
        {
            var identity = await _userManager.FindByEmailAsync(email);
            return identity.Id;
        }

    }
}
