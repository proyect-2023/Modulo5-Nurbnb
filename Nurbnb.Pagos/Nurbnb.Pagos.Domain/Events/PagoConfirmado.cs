using MediatR;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Events
{
    public record PagoConfirmado : DomainEvent,INotification
    {
        public Guid PagoId { get; init; }
        public DetallePagoConfirmado Detalle { get; init; }
        public PagoConfirmado(Guid pagoId,
            DetallePagoConfirmado detalle) : base(DateTime.Now)
        {
            PagoId = pagoId;
            Detalle = detalle;
        }

        public record DetallePagoConfirmado(string cuentaOrigen, string bcoOrigen, decimal totalImporte);
    }
}
