
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.CatalogoDevolucion
{
    public class CatalogoDevolucion: AggregateRoot
    {
        public CatalogoDevolucionDescripcion Descripcion { get; private set; }
        public CatalogoDevolucionDias NroDias { get; private set; }
        public CatalogoDevolucionPorcentaje PorcentajeDescuento { get; private set; }


        public CatalogoDevolucion(string descripcion, int nroDias, int porcentajeDescuento)
        {
            Id = Guid.NewGuid();
            Descripcion = new CatalogoDevolucionDescripcion(descripcion);
            NroDias = new CatalogoDevolucionDias (nroDias);
            PorcentajeDescuento = new CatalogoDevolucionPorcentaje(porcentajeDescuento);
        }
        public CatalogoDevolucion BuscarCatalogo(List<CatalogoDevolucion> listaCatalogo, DateTime fechaInicio, DateTime fechaFin)
        {
            int nroDias = (fechaFin - fechaInicio).Days;
            return listaCatalogo.Where(r => r.NroDias <= nroDias).OrderBy(r => r.NroDias).First();
        }
        private CatalogoDevolucion() { }

    }
}
