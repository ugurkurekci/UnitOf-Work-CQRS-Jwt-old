using Domain.Entities;
using Security.JWT.Services.Abstraction;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Security.JWT.Services.Concrete;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
    {
        _tokenGenerator = tokenGenerator;
        _jwtSettings = jwtSettings;
    }

    public string Generate(User user)
    {
        List<Claim> claims = new()
        {
            new Claim("ID", user.ID.ToString()),
            new Claim("CompanyID",user.EMail)

        };
        return _tokenGenerator.Generate(_jwtSettings.RefreshTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,
           _jwtSettings.RefreshTokenExpirationMinutes, claims);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}