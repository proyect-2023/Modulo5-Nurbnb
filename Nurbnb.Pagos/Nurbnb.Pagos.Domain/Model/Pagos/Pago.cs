using Nurbnb.Pagos.Domain.Events;
using Nurbnb.Pagos.Domain.Exceptions;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Pagos
{
    public class Pago: AggregateRoot
    {
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }
        public TipoPago TipoPago { get; private set; }
        public Guid OperacionId { get; private set; }
        public Decimal CostoTotalRenta { get;private set; }
        public EstadoPago Estado { get; private set; }
        public string CuentaOrigen { get; private set; }
        public string BcoOrigen { get; private set; }

        private readonly ICollection<DetallePago> _detalle;

        public IEnumerable<DetallePago> Detalle => _detalle;

        public Pago(TipoPago tipo, Guid operacionId,decimal valorOpe,  string cuentaOrigen, string bcoOrigen)
        {
            Id = Guid.NewGuid();
            Estado = EstadoPago.Registrado;
            TipoPago = tipo;
            OperacionId = operacionId;
            CostoTotalRenta = valorOpe;
            FechaRegistro = DateTime.Now;
            CuentaOrigen = cuentaOrigen;
            BcoOrigen = bcoOrigen;
            _detalle = new List<DetallePago>();
        }
        public void AgregarDetallePago(Guid catalogoId, int porcentaje, decimal importe)
        {
            if (_detalle.Any(item => item.CatalogoId == catalogoId))
            {
                throw new CatalogoExitsException();
            }
            DetallePago detallePago = new DetallePago(catalogoId, porcentaje, importe);

            _detalle.Add(detallePago);
        }
        public void Confirmar()
        {
            if (Estado != EstadoPago.Registrado)
            {
                throw new EstadoNotFoundException();
            }
            Estado = EstadoPago.Procesado;

            PagoConfirmado.DetallePagoConfirmado detallePago =
                 new PagoConfirmado.DetallePagoConfirmado(CuentaOrigen, BcoOrigen, _detalle.Sum(x => x.Total));
               

            PagoConfirmado evento = new PagoConfirmado(Id, detallePago);
            AddDomainEvent(evento);
        }
        public void Cancelar()
        {
            if (Estado != EstadoPago.Registrado)
            {
                throw new EstadoNotFoundException();
            }
            Estado = EstadoPago.Cancelado;
            FechaCancelacion = DateTime.Now;

            List<PagoCancelado.DetallePagoCancelado> detallePago =
               _detalle.Select(item => new PagoCancelado.DetallePagoCancelado(item.CatalogoId, item.Porcentaje, item.Total))
               .ToList();

            PagoCancelado evento = new PagoCancelado(Id, detallePago);
            AddDomainEvent(evento);
        }

        private Pago() { }
    }
}
