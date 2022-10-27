using Domain.Entities;

namespace Security.JWT.Services.Abstraction;

public interface IRefreshTokenService
{

    string Generate(User user);

}