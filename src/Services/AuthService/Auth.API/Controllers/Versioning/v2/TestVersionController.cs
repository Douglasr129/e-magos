using Asp.Versioning;
using Core.Configuration.APIConfiguration;
using Core.DomainObjects.Interfaces;
using Core.Notifications.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Auth.API.Controllers.Versioning.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class TestVersionController(INotifier notificador) : MainController(notificador)
    {
        [HttpGet("teste")]
        public IActionResult ObterTeste()
        {
            return CustomResponse(HttpStatusCode.OK, new { message = "Teste de versão V2" });
        }
    }
}
