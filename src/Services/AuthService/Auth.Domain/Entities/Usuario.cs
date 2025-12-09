using Auth.Domain.Events;
using Auth.Domain.Exceptions;
using Auth.Domain.ValueObjects;
using Core.DomainObjects.Services;

namespace Auth.Domain.Entities
{
    public class Usuario : AggregateRoot
    {
        public Email Email { get; private set; }
        public Senha SenhaHash { get; private set; }
        public string Nome { get; private set; }
        public SocialLoginProvider? SocialProvider { get; private set; }

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        protected Usuario() { } // EF Core
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.

        public Usuario(string nome, Email email, Senha senhaHash)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AuthDomainException("Nome do usuário não pode ser vazio.");

            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;

            AddEvent(new UsuarioRegistradoEvent(Id, Email.ToString()));
        }

        public void Autenticar(string senha)
        {
            if (!SenhaHash.Validar(senha))
                throw new AuthDomainException("Senha inválida.");

            AddEvent(new UsuarioAutenticadoEvent(Id, Email.ToString()));
        }

        public void Desativar() => base.Active = false;
        public void Ativar() => base.Active = true;

    }
}
