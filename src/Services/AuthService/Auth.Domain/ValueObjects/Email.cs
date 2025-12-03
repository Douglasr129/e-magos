using Core.DomainObjects.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.ValueObjects
{
    /// <summary>
    /// Value Object para representar um e-mail válido.
    /// </summary>
    public record Email
    {
        public string Address { get; }

        public Email(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
                throw new DomainException("E-mail inválido.");

            Address = address;
        }

        public override string ToString() => Address;
    }

}
