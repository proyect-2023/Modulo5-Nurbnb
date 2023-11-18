using MediatR;
using Nurbnb.Pagos.Application.Dto.Devolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Devoluciones.Query.GetDevolucionList
{
    public class GetDevolucionListQuery: IRequest<ICollection<DevolucionDto>>
    {
        public string SearchTerm { get; set; }
    }
}
