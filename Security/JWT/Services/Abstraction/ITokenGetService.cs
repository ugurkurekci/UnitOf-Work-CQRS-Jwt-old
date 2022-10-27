using System.Security.Claims;

namespace Security.JWT.Services.Abstraction;
public interface ITokenGetService
{
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

}
