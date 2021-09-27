using BussinesLayer.Interfaces.Auth;
using Common.Models.Users;
using DataLayer.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly JwtSetting _options;
        public AuthService(IOptions<JwtSetting> options)
        {
            _options = options.Value;
        }

        public string BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _options.ValidIssuer,
               audience: _options.ValidAudience,
               claims: claims,
               signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
