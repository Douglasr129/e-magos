using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainObjects.Models
{
    public class IdentitySettings
    {
        public string JwtSecret { get; set; } = string.Empty;
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public int Expires { get; set; }
    }
}
