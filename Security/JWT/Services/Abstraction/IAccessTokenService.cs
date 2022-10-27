using Domain.Entities;

namespace Security.JWT.Services.Abstraction;

public interface IAccessTokenService  
{

    public string Generate(User user);

}