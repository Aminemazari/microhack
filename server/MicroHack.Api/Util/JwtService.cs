using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MicroHack.Domain;
using Microsoft.IdentityModel.Tokens;

namespace MicroHack.Util;

public static class JwtService
{
    private static string jwtSecret = "dummy_secret_for_development_mode";

    public static void SetJwtSecret(string jwtSecret)
    {
        JwtService.jwtSecret = jwtSecret;
    }

    public static string GenerateJWTToken(User user) {

        var claims = new List<Claim> {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        var jwtToken = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSecret)),
                "HS256")
            );
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
