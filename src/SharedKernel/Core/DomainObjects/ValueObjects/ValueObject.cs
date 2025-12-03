namespace Core.DomainObjects.ValueObjects
{
    /// <summary>
    /// Classe base abstrata para Objetos de Valor (Value Objects) no Domain-Driven Design (DDD).
    /// Value Objects são objetos cuja igualdade é baseada em valor (ou seja, em seus atributos) e não em identidade.
    /// Implementa a igualdade baseada em componentes, sobrescrevendo Equals e GetHashCode.
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Retorna os componentes (atributos) do objeto que devem ser considerados na verificação de igualdade.
        /// As classes filhas devem implementar este método para retornar todos os campos que definem o valor do objeto.
        /// </summary>
        /// <returns>Uma sequência de objetos (atributos) que definem o valor do Value Object.</returns>
        protected abstract IEnumerable<object?> GetEqualityComponents();

        /// <summary>
        /// Sobrescreve o método base para verificar a igualdade de Value Objects com base em seus componentes.
        /// Dois Value Objects são considerados iguais se eles são do mesmo tipo e todos os seus componentes de igualdade são iguais.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com o objeto atual.</param>
        /// <returns><c>true</c> se os objetos forem iguais em valor; caso contrário, <c>false</c>.</returns>
        public override bool Equals(object? obj)
        {
            // 1. Verifica se o objeto é nulo ou não é um ValueObject
            if (obj is not ValueObject other) return false;

            // 2. Compara os componentes de igualdade sequencialmente
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Sobrescreve o método base para gerar um código hash (hash code) com base nos componentes de igualdade.
        /// Isso garante que Value Objects iguais em valor tenham o mesmo hash code.
        /// </summary>
        /// <returns>Um código hash calculado a partir dos componentes de igualdade do objeto.</returns>
        public override int GetHashCode() =>
            GetEqualityComponents()
                // Usa 1 como valor inicial
                .Aggregate(1, (hash, obj) =>
                    // Multiplica o hash atual por um primo (23) e adiciona o hash do componente
                    hash * 23 + (obj?.GetHashCode() ?? 0));


        public static bool operator ==(ValueObject a, ValueObject b) => a?.Equals(b) ?? b is null;
        public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

    }
}
