using Auth.Application.DTOs;
using Auth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace Auth.Application.Queries
{
    /// <summary>
    /// Handler responsável por consultar usuário pelo e-mail.
    /// </summary>
    public class ObterUsuarioPorEmailHandler(IUsuarioRepository context, IMapper mapper) : IRequestHandler<ObterUsuarioPorEmailQuery, UsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository = context;
        private readonly IMapper _mapper = mapper;

        public async Task<UsuarioDTO> Handle(ObterUsuarioPorEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<UsuarioDTO>(await _usuarioRepository.ObterPorEmailAsync(request.Email));
            return usuario;
        }
    }

}
