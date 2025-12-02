using Core.DomainObjects.Services;

namespace Core.Data
{
    /// <summary>
    /// Define um contrato para um repositório que fornece acesso a raízes agregadas do tipo <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>Esta interface garante que os repositórios estejam vinculados a uma unidade de trabalho, representada pela propriedade <see
    /// cref="UnitOfWork"/>. Ela também implementa <see cref="IDisposable"/> para permitir o gerenciamento adequado de recursos
    ///.</remarks>
    /// <typeparam name="T">O tipo da raiz agregada gerenciada pelo repositório. Deve implementar <see cref="AggregateRoot"/>.</typeparam>
    public interface IRepository<T> : IDisposable where T : AggregateRoot
    {
        /// <summary>
        /// Obtém a instância da unidade de trabalho usada para gerir transações e coordenar alterações entre repositórios.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
