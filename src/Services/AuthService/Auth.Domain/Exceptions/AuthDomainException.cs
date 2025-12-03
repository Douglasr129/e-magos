using Core.DomainObjects.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Exceptions
{
    public class AuthDomainException : DomainException
    {
        public AuthDomainException(string message) : base(message) { }
    }

}
