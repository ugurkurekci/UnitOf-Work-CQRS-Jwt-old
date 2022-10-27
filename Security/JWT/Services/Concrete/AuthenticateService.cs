using Domain.Entities;
using Security.JWT.Services.Abstraction;

namespace Security.JWT.Services.Concrete;

public class AuthenticateService : IAuthenticateService
{

    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ITokenGetService _tokenGetService;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, ITokenGetService tokenGetService)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _tokenGetService = tokenGetService;
    }

    public Task<Tokens> Authenticate(User user, CancellationToken cancellationToken)
    {

        string refreshToken = _refreshTokenService.Generate(user);
        return Task.FromResult(new Tokens
        {
            AccessToken = _accessTokenService.Generate(user),
            RefreshToken = refreshToken
        });

    }

    public async Task<Tokens> Authenticate(RefreshRequest refreshRequest)
    {
        var principal = _tokenGetService.GetPrincipalFromExpiredToken(refreshRequest.RefreshToken);
        if (principal == null)
        {
            return new Tokens
            {
                AccessToken = "null",
                RefreshToken = "null"
            };
        }


        var username = principal.Claims;
        var newAccessToken = _accessTokenService.GenerateAccessToken(username);
        var newRefreshToken = _refreshTokenService.GenerateRefreshToken();
        return new Tokens
        {
            RefreshToken = newRefreshToken,
            AccessToken = newAccessToken
        };

    }
}