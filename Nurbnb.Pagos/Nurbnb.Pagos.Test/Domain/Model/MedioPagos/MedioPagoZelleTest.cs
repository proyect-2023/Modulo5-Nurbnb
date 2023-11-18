using Nurbnb.Pagos.Domain.Model.MedioPagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.MedioPagos
{
    public class MedioPagoZelleTest
    {
        [Fact]
        public void Pagar()
        {
            string valorEsperado = "Zelle";

            Assert.Contains(valorEsperado, new MedioPagoZelle().ProcesarPago());
        }
    }
}
