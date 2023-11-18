using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Nurbnb.Pagos.Domain.Factories
{
    public class PagoFactory : IPagoFactory
    {
        public Pago CrearPago(int tipoPago ,Guid operacionId, decimal valorOpe, string cuentaOrigen, string bcoOrigen)
        {
            return new Pago((tipoPago== 1 ?TipoPago.Reserva:TipoPago.Cobro),operacionId,valorOpe, cuentaOrigen, bcoOrigen);
        }

       
    }
}
