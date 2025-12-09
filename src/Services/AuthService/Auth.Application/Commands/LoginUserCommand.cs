using MediatR;

namespace Auth.Application.Commands
{
    public record LoginUserCommand(string Email, string Senha) : IRequest<string>;
}
