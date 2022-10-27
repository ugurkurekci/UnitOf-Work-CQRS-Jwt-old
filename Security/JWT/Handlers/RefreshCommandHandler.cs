using AutoMapper;
using Domain.Entities;
using MediatR;
using Security.JWT.Services.Abstraction;

namespace Security.JWT.Services.Handlers;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, Tokens>
{

    private readonly IAuthenticateService _authenticateService;
    private readonly IRefreshTokenValidator _refreshTokenValidator;
    private readonly IMapper _mapper;

    public RefreshCommandHandler(IRefreshTokenValidator refreshTokenValidator,
         IAuthenticateService authenticateService,
         IMapper mapper)
    {
        _refreshTokenValidator = refreshTokenValidator;
        _authenticateService = authenticateService;
        _mapper = mapper;
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
        User userid = _mapper.Map<User>(request.RefreshRequest);
        return await _authenticateService.Authenticate(request.RefreshRequest);

    }

}