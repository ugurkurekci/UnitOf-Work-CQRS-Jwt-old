using System.Security.Claims;

namespace Security.JWT.Services.Abstraction;

public interface ITokenGenerator
{

    string Generate(string secretKey, string issuer, string audience, double expires,
       IEnumerable<Claim> claims = null);

}