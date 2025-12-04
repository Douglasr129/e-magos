using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Extensions.APIExtensions
{
#pragma warning disable CS8767 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao membro implementado implicitamente (possivelmente devido a atributos de nulidade).
#pragma warning disable CS8603 // Possível retorno de referência nula.
#pragma warning disable SYSLIB1045 // Converter em 'GeneratedRegexAttribute'.
#pragma warning disable CS8604 // Possível argumento de referência nula.
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null) return null;

            // Converte para minúsculas e substitui espaços por hífens
            return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
#pragma warning restore CS8604 // Possível argumento de referência nula.
#pragma warning restore SYSLIB1045 // Converter em 'GeneratedRegexAttribute'.
#pragma warning restore CS8603 // Possível retorno de referência nula.
#pragma warning restore CS8767 // A nulidade de tipos de referência no tipo de parâmetro não corresponde ao membro implementado implicitamente (possivelmente devido a atributos de nulidade).

}
