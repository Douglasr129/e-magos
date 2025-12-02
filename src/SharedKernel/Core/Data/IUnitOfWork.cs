namespace Core.Data
{
    /// <summary>
    /// Define um contrato para uma unidade de trabalho que encapsula operações transacionais.
    /// </summary>
    /// <remarks>O padrão de unidade de trabalho é usado para agrupar várias operações em uma única transação. 
    /// As implementações desta interface devem garantir que todas as alterações sejam confirmadas atomicamente  ou revertidas em
    /// caso de falha.</remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Guarda todas as alterações feitas na unidade de trabalho atual no armazenamento de dados subjacente.
        /// </summary>
        /// <remarks>Este método confirma a transação atual, garantindo que todas as alterações pendentes sejam
        /// mantidas.  Se a operação de confirmação falhar, as alterações são revertidas e o método retorna <see
        /// langword="false"/>.</remarks>
        /// <returns><see langword="true"/> se as alterações foram confirmadas com sucesso; caso contrário, <see langword="false"/>.</returns>
        Task<bool> Commit();
    }
}
