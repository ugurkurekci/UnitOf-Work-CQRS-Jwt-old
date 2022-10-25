using Domain.Entities;
using MediatR;

namespace Security.JWT.Services.Handlers;
public class RefreshCommand : IRequest<Tokens>
{
    public User User { get; set; }
    public RefreshRequest RefreshRequest { get; set; }

    public RefreshCommand(User user, RefreshRequest refreshRequest)
    {
        User = user;
        RefreshRequest = refreshRequest;
    }
}
