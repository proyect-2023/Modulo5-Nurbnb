using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public class CatalogoDevolucionFactory : ICatalogoDevolucionFactory
    {
        public CatalogoDevolucion BuscarCatalogo(List<CatalogoDevolucion> listaCatalogo, DateTime fechaInicio, DateTime fechaFin)
        {
            return BuscarCatalogo(listaCatalogo,fechaInicio,fechaFin);
        }

        public CatalogoDevolucion CrearCatalogoDevolucion(string descripcion, int nroDias, int porcentajeDescuento)
        {
            return new CatalogoDevolucion(descripcion, nroDias, porcentajeDescuento);
        }
    }
}
