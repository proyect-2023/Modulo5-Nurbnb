using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.Security
{
    internal class JwtOptions
    {
        public const string SectionName = "JwtOptions";
        public string SecretKey { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public long Lifetime { get; set; }

        public JwtOptions()
        {
            SecretKey = "";
            ValidIssuer = "";
            ValidAudience = "";
        }
    }
}
