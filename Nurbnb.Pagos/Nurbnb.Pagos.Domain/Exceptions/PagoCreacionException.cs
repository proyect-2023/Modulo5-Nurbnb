using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class PagoCreacionException:Exception
    {
        public PagoCreacionException(string motivo)
            : base("La transacción no puede ser creada por que " + motivo)
        {
        }
    }
}
