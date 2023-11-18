using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Events
{
    public record PagoCancelado : DomainEvent
    {
        public Guid PagoId { get; init; }
        public ICollection<DetallePagoCancelado> Detalle { get; init; }
        public PagoCancelado(Guid pagoId,
            ICollection<DetallePagoCancelado> detalle) : base(DateTime.Now)
        {
            PagoId = pagoId;
            Detalle = detalle;
        }

        public record DetallePagoCancelado(Guid catalogoId, int porcentaje, decimal totalImporte);
    }
}
