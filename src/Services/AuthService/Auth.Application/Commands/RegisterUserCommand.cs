using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Application.Commands
{
    public record RegisterUserCommand(string Nome, string Email, string Senha) : IRequest<string>;
}
