using MediatR;
using Nurbnb.Pagos.Application.Dto.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Pagos.Query.GetPagoList
{
    public class GetPagoListQuery: IRequest<ICollection<PagoDto>>
    {
        public string SearchTerm { get; set; }
    }
}
