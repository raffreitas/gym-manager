using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using GymManager.Core;
using GymManager.Core.Enums;
using GymManager.Core.Services;

using Microsoft.IdentityModel.Tokens;

namespace GymManager.Infrastructure.AuthServices;
public class AuthService : IAuthService
{
    public string GenerateToken(Guid id, Role role)
    {
        var jwtKey = Configuration.Secrets.JwtSecretKey;
        var audience = Configuration.Secrets.JwtAudience;
        var issuer = Configuration.Secrets.JwtIssuer;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new (JwtRegisteredClaimNames.Sub, id.ToString()),
            new (ClaimTypes.Role, Enum.GetName(role) ?? string.Empty)
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: credentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    public string HashPassword(string plainPassword)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(plainPassword));

        StringBuilder sb = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }

        return sb.ToString();
    }
}
