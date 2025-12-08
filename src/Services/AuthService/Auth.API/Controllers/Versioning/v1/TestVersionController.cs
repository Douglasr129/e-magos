using Asp.Versioning;
using Core.Configuration.APIConfiguration;
using Core.DomainObjects.Interfaces;
using Core.Notifications.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers.Versioning.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[action]")]
    public class TestVersionController(INotifier notificador, IUsuarioContextoProvider User) : MainController(notificador, User)
    {
        [HttpGet("teste")]
        public IEnumerable<string> ObterTeste()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
