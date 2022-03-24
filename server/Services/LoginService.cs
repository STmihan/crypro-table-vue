using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using server.Models;

namespace server.Services;

public class LoginService
{
    public string CreateJwt(IConfiguration configuration, User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username)
        };

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Audience"],
            audience: configuration["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(30),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }

    public LoginResponse VerifyUser(UserLogin userLogin)
    {
        
    }
}

public class LoginResponse
{
    public string? Token { get; set; }
    public string Username { get; set; }
    public List<Coin> Coins { get; set; }
}