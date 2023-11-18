using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public interface ICatalogoDevolucionFactory
    {
        CatalogoDevolucion CrearCatalogoDevolucion(string descripcion, int nroDias, int porcentajeDescuento);
        CatalogoDevolucion BuscarCatalogo(List<CatalogoDevolucion> listaCatalogo, DateTime fechaInicio, DateTime fechaFin);
    }
}
