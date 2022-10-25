using Domain.Entities;

namespace Security.JWT.Services;
public class RefreshRequest
{
    public User user { get; set; }
    public string RefreshToken { get; set; }
}
