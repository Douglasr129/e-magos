using Auth.Application.Commands;
using Auth.Application.DTOs;
using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace Auth.Application.CommandHandlers
{
    public class RegisterUserCommandHandler(IUsuarioRepository context, IMapper mapper) : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUsuarioRepository _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var usuario = new UsuarioDTO
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                SenhaHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Senha)
            };
            var usuarioReg = _mapper.Map<UsuarioDTO>(await _context.ObterPorEmailAsync(usuario.Email));
            if (usuarioReg != null)
            {
                return "Email já registrado.";
            }
            await _context.AdicionarAsync(_mapper.Map<Usuario>(usuario));
            return "Usuário registrado com sucesso!";
        }
    }
}
