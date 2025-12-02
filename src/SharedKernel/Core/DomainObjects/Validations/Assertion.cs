using Core.DomainObjects.DomainExceptions;
using System.Text.RegularExpressions;

namespace Core.DomainObjects.Validations
{
    /// <summary>
    /// Fornece métodos estáticos para fazer asserções (validações) em objetos e valores.
    /// Esta classe é tipicamente usada em classes de Domínio (Entidades, Value Objects)
    /// para garantir a integridade do estado e lançar uma <see cref="DomainException"/>.
    /// </summary>
    public static class Assertion
    {
        /// <summary>
        /// Afirma que dois objetos são diferentes. Lança <see cref="DomainException"/> se forem iguais.
        /// </summary>
        /// <param name="object1">O primeiro objeto a ser comparado.</param>
        /// <param name="object2">O segundo objeto a ser comparado.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="object1"/> for igual a <paramref name="object2"/>.</exception>
        public static void AssertNotEqual(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que dois objetos são iguais. Lança <see cref="DomainException"/> se forem diferentes.
        /// </summary>
        /// <param name="object1">O primeiro objeto a ser comparado.</param>
        /// <param name="object2">O segundo objeto a ser comparado.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="object1"/> não for igual a <paramref name="object2"/>.</exception>
        public static void AssertEqual(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor de string corresponde a um padrão de expressão regular (Regex).
        /// </summary>
        /// <param name="value">A string a ser validada.</param>
        /// <param name="pattern">O padrão de Regex que a string deve corresponder.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> não corresponder ao <paramref name="pattern"/>.</exception>
        public static void AssertMatches(string value, string pattern, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que o comprimento de uma string não excede o valor máximo permitido.
        /// </summary>
        /// <param name="value">A string a ser verificada.</param>
        /// <param name="maximum">O comprimento máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se o comprimento da string for maior que <paramref name="maximum"/>.</exception>
        public static void AssertMaxLength(string value, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que o comprimento de uma string está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">A string a ser verificada.</param>
        /// <param name="minimum">O comprimento mínimo permitido.</param>
        /// <param name="maximum">O comprimento máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se o comprimento estiver fora do intervalo especificado.</exception>
        public static void AssertLengthRange(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que uma string não é nula, vazia ou composta apenas por espaços em branco.
        /// </summary>
        /// <param name="value">A string a ser verificada.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se a string for nula, vazia ou whitespace.</exception>
        public static void AssertNotEmpty(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um objeto não é nulo. Lança <see cref="DomainException"/> se for nulo.
        /// </summary>
        /// <param name="object1">O objeto a ser verificado.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="object1"/> for nulo.</exception>
        public static void AssertNotNull(object object1, string message)
        {
            if (object1 == null)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (double) está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">O valor numérico a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="maximum">O valor máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> estiver fora do intervalo.</exception>
        public static void AssertRange(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (float) está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">O valor numérico a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="maximum">O valor máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> estiver fora do intervalo.</exception>
        public static void AssertRange(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (int) está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">O valor numérico a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="maximum">O valor máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> estiver fora do intervalo.</exception>
        public static void AssertRange(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (long) está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">O valor numérico a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="maximum">O valor máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> estiver fora do intervalo.</exception>
        public static void AssertRange(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (decimal) está dentro de um intervalo (mínimo e máximo).
        /// </summary>
        /// <param name="value">O valor numérico a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="maximum">O valor máximo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> estiver fora do intervalo.</exception>
        public static void AssertRange(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (long) não é menor que o mínimo especificado.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> for menor que <paramref name="minimum"/>.</exception>
        public static void AssertMinimum(long value, long minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (double) não é menor que o mínimo especificado.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> for menor que <paramref name="minimum"/>.</exception>
        public static void AssertMinimum(double value, double minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (decimal) não é menor que o mínimo especificado.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> for menor que <paramref name="minimum"/>.</exception>
        public static void AssertMinimum(decimal value, decimal minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor numérico (int) não é menor que o mínimo especificado.
        /// </summary>
        /// <param name="value">O valor a ser verificado.</param>
        /// <param name="minimum">O valor mínimo permitido.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="value"/> for menor que <paramref name="minimum"/>.</exception>
        public static void AssertMinimum(int value, int minimum, string message)
        {
            if (value < minimum)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor booleano é verdadeiro (<c>true</c>). Lança <see cref="DomainException"/> se for falso.
        /// </summary>
        /// <param name="boolValue">O valor booleano a ser verificado.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="boolValue"/> for <c>false</c>.</exception>
        public static void AssertTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                throw new DomainException(message);
            }
        }

        /// <summary>
        /// Afirma que um valor booleano é falso (<c>false</c>). Lança <see cref="DomainException"/> se for verdadeiro.
        /// </summary>
        /// <param name="boolValue">O valor booleano a ser verificado.</param>
        /// <param name="message">A mensagem de erro a ser usada na exceção.</param>
        /// <exception cref="DomainException">Lançada se <paramref name="boolValue"/> for <c>true</c>.</exception>
        public static void AssertFalse(bool boolValue, string message)
        {
            if (boolValue)
            {
                throw new DomainException(message);
            }
        }
    }
}
