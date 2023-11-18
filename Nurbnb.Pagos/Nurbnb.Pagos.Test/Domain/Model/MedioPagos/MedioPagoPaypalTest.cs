using Nurbnb.Pagos.Domain.Model.MedioPagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.MedioPagos
{
    public class MedioPagoPaypalTest
    {
        [Fact]
        public void Pagar()
        {
            string valorEsperado = "Paypal";
    
            Assert.Contains(valorEsperado, new MedioPagoPaypal().ProcesarPago());
        }
    }
}
