using MediatR;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucion
{
    public class GetCatalogoDevolucionQuery : IRequest<CatalogoDevolucionDto>
    {
        public DateTime FechaAprobacionReserva { get; set; }
        public DateTime FechaInicioEstadia { get; set; }
    }
}
