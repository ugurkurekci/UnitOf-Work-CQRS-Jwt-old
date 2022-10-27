using MediatR;
using Security.JWT.Services.Abstraction;

namespace Security.JWT.Services.Handlers;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, Tokens>
{

    private readonly IAuthenticateService _authenticateService;
    private readonly IRefreshTokenValidator _refreshTokenValidator;

    public RefreshCommandHandler(IRefreshTokenValidator refreshTokenValidator,
         IAuthenticateService authenticateService)
    {
        _refreshTokenValidator = refreshTokenValidator;
        _authenticateService = authenticateService;
    }

    public async Task<Tokens> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        RefreshRequest refreshRequest = request.RefreshRequest;
        bool isValidRefreshToken = _refreshTokenValidator.Validate(refreshRequest.RefreshToken);
        if (!isValidRefreshToken)
        {
            return new Tokens
            {
                AccessToken = "!isValidRefreshToken",
                RefreshToken = "!isValidRefreshToken",

            };
        }

        return await _authenticateService.Authenticate(request.User, cancellationToken);

    }

}