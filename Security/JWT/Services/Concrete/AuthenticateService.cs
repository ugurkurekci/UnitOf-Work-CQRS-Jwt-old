using Domain.Entities;
using Security.JWT.Services.Abstraction;

namespace Security.JWT.Services.Concrete;

public class AuthenticateService : IAuthenticateService
{

    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
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

}