using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.MedioPagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.MedioPagos
{
    public class MedioPagoTest
    {
        [Fact]
        public void PagarImporteMayorACero()
        {
            int valorEsperadoImporte = 15;
            string cuenta = "123456";
            string banco = "012";
            int importe = 15;

            MedioPago medio = new MedioPago(new Guid(),cuenta,banco, importe);
            medio.Pagar();
            Assert.Equal(valorEsperadoImporte, medio.Importe);
        }
    }
}
