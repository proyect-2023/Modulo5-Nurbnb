using Nurbnb.Pagos.Domain.Model.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public class DevolucionFactory : IDevolucionFactory
    {
        public Devolucion CrearDevolucion(Guid pagoId, Guid catalogoDevolucionId, int porcentajeDevolucion, decimal importePago)
        {
            return new Devolucion(pagoId,catalogoDevolucionId, porcentajeDevolucion,importePago);
        }
    }
}
