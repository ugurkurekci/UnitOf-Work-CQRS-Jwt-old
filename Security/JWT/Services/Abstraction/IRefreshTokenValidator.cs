namespace Security.JWT.Services.Abstraction;

public interface IRefreshTokenValidator
{

    bool Validate(string refreshToken);

}