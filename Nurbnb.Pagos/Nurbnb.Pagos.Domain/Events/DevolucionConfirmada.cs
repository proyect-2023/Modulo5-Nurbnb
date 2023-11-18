using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Events
{
    public record  DevolucionConfirmada: DomainEvent
    {
        public Guid DevolucionId { get; init; }
        public DetalleDevolucionConfirmada Detalle { get; init; }
        public DevolucionConfirmada(Guid transaccionId,
            DetalleDevolucionConfirmada detalle) : base(DateTime.Now)
        {
            DevolucionId = transaccionId;
            Detalle = detalle;
        }

        public record DetalleDevolucionConfirmada(Guid pagoId,  Guid catalogoid, decimal totalDevolucion);
    }
}
