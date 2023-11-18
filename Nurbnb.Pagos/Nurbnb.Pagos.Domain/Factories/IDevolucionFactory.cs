using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public interface IDevolucionFactory
    {
        Devolucion CrearDevolucion(Guid pagoId, Guid catalogoDevolucionId, int porcentajeDevolucion, decimal importePago);
    }
}
