using Domain.Entities;
using System.Security.Claims;

namespace Security.JWT.Services.Abstraction;

public interface IAccessTokenService  
{

    public string Generate(User user);

   public string GenerateAccessToken(IEnumerable<Claim> claims);

}