using Core.DomainObjects.ValueObjects;

namespace Core.DomainObjects.Interfaces
{
    /// <summary>
    /// Interface para acessar o usuário autenticado na requisição.
    /// </summary>
    public interface IUsuarioContextoProvider
    {
        UsuarioContexto ObterUsuario();
    }

}
