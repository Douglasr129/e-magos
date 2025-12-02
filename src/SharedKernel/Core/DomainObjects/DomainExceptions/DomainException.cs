using System.Runtime.Serialization;

namespace Core.DomainObjects.DomainExceptions
{
    /// <summary>
    /// Representa erros que ocorrem na camada de domínio de uma aplicação.
    /// </summary>
    /// <remarks>
    /// Esta exceção destina-se a encapsular erros específicos do domínio, proporcionando uma distinção clara
    /// entre problemas relacionados com o domínio e outros tipos de exceções. É utilizada para sinalizar
    /// violações de regras de negócio, invariantes de entidade ou outras restrições do domínio.
    /// </remarks>
    [Serializable] // Boa prática para exceções
    public class DomainException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainException"/>.
        /// </summary>
        public DomainException()
        { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainException"/> com uma mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DomainException(string message) : base(message)
        { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainException"/> com uma mensagem de erro especificada
        /// e uma referência à exceção interna que é a causa desta exceção.
        /// </summary>
        /// <param name="message">A mensagem de erro que explica a razão da exceção.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.</param>
        public DomainException(string message, Exception innerException) : base(message, innerException)
        { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DomainException"/> com dados serializados.
        /// Este construtor é exigido para que as classes de exceção sejam serializáveis.
        /// </summary>
        /// <param name="info">O objeto que mantém os dados de objeto serializados.</param>
        /// <param name="context">As informações contextuais sobre a origem ou destino.</param>
#pragma warning disable SYSLIB0051 // O tipo ou membro é obsoleto
        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // O tipo ou membro é obsoleto
        { }
    }
}
