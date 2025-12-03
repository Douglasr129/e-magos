using Auth.Domain.Exceptions;

namespace Auth.Domain.ValueObjects
{
    public record Senha
    {
        private const int MinLength = 8;
        public string Valor { get; }

        public Senha(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < MinLength)
                throw new AuthDomainException($"Senha deve ter pelo menos {MinLength} caracteres.");

            // Validação básica: deve conter letras e números
            if (!valor.Any(char.IsLetter) || !valor.Any(char.IsDigit))
                throw new AuthDomainException("Senha deve conter letras e números.");

            Valor = valor;
        }

        public bool Validar(string senha) => Valor == senha;
    }

}
