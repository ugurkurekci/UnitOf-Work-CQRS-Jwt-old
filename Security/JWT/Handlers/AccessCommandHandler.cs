using MediatR;
using Security.JWT.Services.Abstraction;

namespace Security.JWT.Services.Handlers;

public class AccessCommandHandler : IRequestHandler<AccessCommand, Tokens>
{

    private readonly IAuthenticateService _authenticateService;

    public AccessCommandHandler(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    public async Task<Tokens> Handle(AccessCommand request, CancellationToken cancellationToken)
    {
        return await _authenticateService.Authenticate(request.user, cancellationToken);
    }

}