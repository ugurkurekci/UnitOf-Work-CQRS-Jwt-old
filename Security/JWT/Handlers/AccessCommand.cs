using Domain.Entities;
using MediatR;

namespace Security.JWT.Services.Handlers;

public record AccessCommand(User user) : IRequest<Tokens> { }