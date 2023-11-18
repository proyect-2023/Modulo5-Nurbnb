using Nurbnb.Pagos.Domain.Exceptions;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.MedioPagos
{
    public class MedioPago:AggregateRoot
    {
        private readonly IMedioPago _medioPago;

        public Guid PagoId { get; private set; }
        public string CuentaOrigen { get; private set; }
        public string BcoOrigen { get; private set; }
        public decimal Importe { get; private set; }
        public string ComprobanteExterno { get; private set; }

        public MedioPago(Guid pagoId,string cuentaOrigen, string bcoOrigen, decimal importe)
        {
            CuentaOrigen = cuentaOrigen;
            BcoOrigen= bcoOrigen;
            Importe = importe;
            PagoId = pagoId;
            _medioPago = CrearMedioPago();
            ComprobanteExterno = string.Empty;
        }
        protected virtual IMedioPago CrearMedioPago() { return new MedioPagoPaypal(); }
        public void Pagar()
        {
            if (Importe < 0)
            {
               throw new ValorNotNegativeException();
            }
            if (Importe > 0)
            {
                ComprobanteExterno = _medioPago.ProcesarPago();
            }
            
        }

    }
}
