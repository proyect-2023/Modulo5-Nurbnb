using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ValorNotNegativeException:Exception
    {
        public ValorNotNegativeException()
            : base("Valor no puede ser negativo")
        {
        }
    }
}
