using Domain.Entities;
using Security.JWT.Services.Abstraction;
using System.Security.Claims;

namespace Security.JWT.Services.Concrete;
public class AccessTokenService : IAccessTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
    {
        _tokenGenerator = tokenGenerator;
        _jwtSettings = jwtSettings;
    }

    public string Generate(User user)
    {
        List<Claim> claims = new()
        {
            new Claim("ID", user.ID.ToString())

        };
        return _tokenGenerator.Generate(_jwtSettings.AccessTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,
            _jwtSettings.AccessTokenExpirationMinutes, claims);
    }
}