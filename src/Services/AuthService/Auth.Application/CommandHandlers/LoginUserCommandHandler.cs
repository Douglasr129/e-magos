using Auth.Application.Commands;
using Auth.Application.DTOs;
using Auth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace Auth.Application.CommandHandlers
{
    public class LoginUsuarioCommandHandler(IUsuarioRepository context, IMapper mapper) : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IUsuarioRepository _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<UsuarioDTO>(await _context.ObterPorEmailAsync(request.Email));

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
                return "Credenciais inválidas";

            // Geração do JWT aqui
            return "jwt-gerado-aqui";
        }
    }
}
