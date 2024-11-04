using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DreamRosterBuilding.WebApi.Jwt
{
    public static class JwtHelper // static helper
    {
        public static string GenerateToken(JwtDto jwtInfo)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecretKey));

            // ▼ Credentials ▼
            var credentials = new SigningCredentials(secretKey,SecurityAlgorithms.HmacSha256); // -> Microsoft advice 256 bit security algorithm

            // ▼ Claims ▼
            var claims = new[] // -> Microsoft Identity already have claim subjects but I created 'JwtClaimNames' for custumization
            {
                new Claim(JwtClaimNames.Id,jwtInfo.Id.ToString()),
                new Claim(JwtClaimNames.FirstName,jwtInfo.FirstName),
                new Claim(JwtClaimNames.LastName,jwtInfo.LastName),
                new Claim(JwtClaimNames.Email,jwtInfo.Email),
                new Claim(JwtClaimNames.UserRole,jwtInfo.UserRole.ToString()),

                // ▼ Authorization ▼
                new Claim(ClaimTypes.Role,jwtInfo.UserRole.ToString())
            };

            var expireTime = DateTime.Now.AddMinutes(jwtInfo.ExpireMinutes); // -> Defining expire time

            var tokenDescriptor = new JwtSecurityToken(jwtInfo.Issuer, jwtInfo.Audience, claims, null, expireTime, credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor); // -> Creating token

            return token;
        }
    }
}
