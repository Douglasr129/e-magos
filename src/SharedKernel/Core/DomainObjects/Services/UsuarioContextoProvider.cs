using Core.DomainObjects.Interfaces;
using Core.DomainObjects.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainObjects.Services
{
    internal class UsuarioContextoProvider : IUsuarioContextoProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsuarioContextoProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UsuarioContexto ObterUsuario()
        {
            throw new NotImplementedException();
        }

    }
}
