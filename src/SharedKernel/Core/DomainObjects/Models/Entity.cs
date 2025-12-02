using System.Globalization;
using System.Text;

namespace Core.DomainObjects.Models
{
    /// <summary>
    /// Representa a classe base para entidades com um identificador único e propriedades comuns.
    /// </summary>
    /// <remarks>Esta classe abstrata fornece uma base para objetos de entidade, incluindo um identificador único
    /// (<see cref="Id"/>), carimbos de data/hora de criação (<see cref="DataCadastro"/>) e modificação (<see
    /// cref="DataModificacao"/>) e um estado de ativação (<see cref="Ativo"/>). Também inclui lógica de comparação de igualdade
    /// com base no identificador único.</remarks>
    public abstract class Entity
    {
        /// <summary>
        /// Obtém ou define o identificador exclusivo da entidade.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Obtém ou define a data de cadastro da entidade.
        /// </summary>
        public DateTime RegistrationDate { get; set; }
        /// <summary>
        /// Obtém ou define a data de modificação da entidade.
        /// </summary>
        public DateTime ModificationDate { get; set; }
        /// <summary>
        /// Obtém ou define um valor que indica se a entidade está ativa.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <remarks>The constructor generates a unique identifier for the entity and sets the creation
        /// date to the current date and time.</remarks>
        protected Entity()
        {
            Id = Guid.NewGuid();
            RegistrationDate = DateTime.Now;
        }
        /// <summary>
        /// Determina se o objeto especificado é igual à instância atual.
        /// </summary>
        /// <remarks>Duas instâncias são consideradas iguais se forem a mesma referência ou se os seus valores <see
        /// cref="Id"/> forem iguais.</remarks>
        /// <param name="obj">O objeto a ser comparado com a instância atual. Deve ser do tipo <see cref="Entity"/>.</param>
        /// <returns><see langword="true"/> se o objeto especificado for igual à instância atual; caso contrário, <see
        /// langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;
            return Id.Equals(compareTo!.Id);
        }
        /// <summary>
        /// Determina se duas instâncias <see cref="Entity"/> são iguais.
        /// </summary>
        /// <param name="a">A primeira instância <see cref="Entity"/> a ser comparada. Pode ser <see langword="null"/>.</param>
        /// <param name="b">A segunda instância <see cref="Entity"/> a ser comparada. Pode ser <see langword="null"/>.</param>
        /// <returns><see langword="true"/> se ambos <paramref name="a"/> e <paramref name="b"/> forem <see langword="null"/> ou
        /// se forem iguais de acordo com <see cref="object.Equals(object)"/>; caso contrário, <see langword="false"/>.</returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        /// <summary>
        /// Determina se duas instâncias <see cref="Entity"/> não são iguais.
        /// </summary>
        /// <param name="a">A primeira <see cref="Entity"/> a ser comparada.</param>
        /// <param name="b">A segunda <see cref="Entity"/> a ser comparada.</param>
        /// <returns><see langword="true"/> se as duas instâncias <see cref="Entity"/> não forem iguais; caso contrário, <see
        /// langword="false"/>.</returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Serves as the default hash function for the object.
        /// </summary>
        /// <remarks>This method generates a hash code based on the type of the object and the value of
        /// the <see cref="Id"/> property. It is suitable for use in hashing algorithms and data structures such as hash
        /// tables.</remarks>
        /// <returns>An integer that represents the hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 411 + Id.GetHashCode();
        }
        /// <summary>
        /// Serve como função hash padrão para o objeto.
        /// </summary>
        /// <remarks>Este método gera um código hash com base no tipo do objeto e no valor da
        /// propriedade <see cref="Id"/>. É adequado para uso em algoritmos de hash e estruturas de dados, como tabelas hash
        /// .</remarks>
        /// <returns>Um inteiro que representa o código hash para o objeto atual.</returns>
        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
        /// <summary>
        /// Normaliza a string especificada removendo sinais diacríticos (acentos), convertendo-a para maiúsculas e
        /// removendo espaços em branco à esquerda e à direita.
        /// </summary>
        /// <param name="texto">A string de entrada a ser normalizada. Pode ser nula ou conter espaços em branco.</param>
        /// <returns>Uma string normalizada com os sinais diacríticos removidos, convertida para maiúsculas e com os espaços em branco removidos. Se
        /// a string de entrada for nula ou consistir apenas em espaços em branco, a string original será devolvida.</returns>
        protected static string NormalizaString(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            // Normaliza o texto para FormD, decompondo caracteres acentuados
            var textoNormalizado = texto.Normalize(NormalizationForm.FormD);

            // Filtra os caracteres não espaciais
            var sb = new StringBuilder();
            foreach (var c in textoNormalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Retorna o texto sem acentuações no formato composto
            return sb.ToString().Normalize(NormalizationForm.FormC).ToUpper().Trim();
        }

    }
}
