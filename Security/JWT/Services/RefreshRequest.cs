using Domain.Entities;

namespace Security.JWT.Services;

public class RefreshRequest
{
    public string RefreshToken { get; set; }

}