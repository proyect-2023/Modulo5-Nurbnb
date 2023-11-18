using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class EstadoNotFoundException:Exception
    {
        public EstadoNotFoundException()
            : base("El pago no tiene el estado Registrado")
        {
        }
    }
}
