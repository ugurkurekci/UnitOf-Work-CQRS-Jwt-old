using Domain.Entities;

namespace Security.JWT.Services.Abstraction;
public interface IAuthenticateService
{

    Task<Tokens> Authenticate(User user, CancellationToken cancellationToken);
}