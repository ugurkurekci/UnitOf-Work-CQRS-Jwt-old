using Domain.Entities;
using System.Security.Claims;

namespace Security.JWT.Services.Abstraction;

public interface IAuthenticateService
{

    Task<Tokens> Authenticate(User user, CancellationToken cancellationToken);
    Task<Tokens> Authenticate(RefreshRequest refreshRequest);


}