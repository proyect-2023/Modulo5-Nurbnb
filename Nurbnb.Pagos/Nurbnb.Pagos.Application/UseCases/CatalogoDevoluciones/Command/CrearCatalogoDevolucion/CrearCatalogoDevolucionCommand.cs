using MediatR;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Command.CrearCatalogoDevolucion
{
    public class CrearCatalogoDevolucionCommand: IRequest<Guid>
    {
        public string Descripcion { get; set; }
        public int NroDias { get; set; }
        public int PorcentajeDescuento { get;  set; }
    }
}
