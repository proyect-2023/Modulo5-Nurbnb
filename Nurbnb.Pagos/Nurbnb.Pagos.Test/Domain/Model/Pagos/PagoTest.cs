using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Pagos
{
    public class PagoTest
    {
        [Fact]
        public void ConfirmarPago()
        {
            EstadoPago valorEsperadoEstado = EstadoPago.Procesado;
            TipoPago tipo = TipoPago.Reserva;
            Guid operacion = Guid.NewGuid();
            int valor = 15;
            string cuenta = "12345";
            string bco = "012";

            Pago pago = new Pago(tipo, operacion,valor,cuenta,bco);
            pago.Confirmar();

            Assert.Equal(valorEsperadoEstado, pago.Estado);
            Assert.Equal(tipo, pago.TipoPago);
            Assert.Equal(cuenta, pago.CuentaOrigen);
            Assert.Equal(operacion, pago.OperacionId);
            Assert.Equal(bco, pago.BcoOrigen);
            Assert.Equal(valor, pago.CostoTotalRenta);
            Assert.Equal(DateTime.Now.ToShortDateString(), pago.FechaRegistro.ToShortDateString());
        }

        [Fact]
        public void CancelarPago()
        {
            EstadoPago valorEsperadoEstado = EstadoPago.Cancelado;
            TipoPago tipo = TipoPago.Reserva;
            Guid operacion = Guid.NewGuid();
            int valor = 15;
            string cuenta = "12345";
            string bco = "012";

            Pago pago = new Pago(tipo, operacion, valor, cuenta, bco);
            pago.Cancelar();

            Assert.Equal(valorEsperadoEstado, pago.Estado);
        }
        [Fact]
        public void AgregarDetallePago()
        {
            int cantidadEsperado = 1;
            TipoPago tipo = TipoPago.Reserva;
            Guid operacion = Guid.NewGuid();
            int valor = 15;
            string cuenta = "12345";
            string bco = "012";
            Guid catalogoId= Guid.NewGuid();
            int porcentaje = 50;
            Decimal importe = 100;


            Pago pago = new Pago(tipo, operacion, valor, cuenta, bco);
            pago.AgregarDetallePago(catalogoId,porcentaje,importe);

            Assert.True(cantidadEsperado == pago.Detalle.Count());
        }
    }
}
