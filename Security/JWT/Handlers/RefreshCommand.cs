using Domain.Entities;
using MediatR;

namespace Security.JWT.Services.Handlers;

public class RefreshCommand : IRequest<Tokens>
{

    public RefreshRequest RefreshRequest { get; set; }

    public RefreshCommand( RefreshRequest refreshRequest)
    {
        RefreshRequest = refreshRequest;
    }

}