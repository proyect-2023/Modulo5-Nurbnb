using MediatR;
using Nurbnb.Pagos.Application.Dto.Pago;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago
{
    public class CrearPagoCommand:IRequest<Guid>
    {
       // public TipoPagos TipoPago { get; set; }
        public Guid OperacionId { get; set; }
       // public Decimal CostoTotalRenta { get; set; }
        public Guid PropiedadId { get; set; }
        public Guid CatalogoId { get; set; }
    // public string BcoOrigen { get; set; }
    // public List<ItemDetallePago> Detalle { get; set; }
}
}
