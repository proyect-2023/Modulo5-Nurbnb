using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Factories
{
    public class PagoFactoryTest
    {
        [Fact]
        public void CrearPago()
        {
            int tipo = 1;
            Guid operacion= Guid.NewGuid();
            decimal valor = 100;
            string cuenta = "123456";
            string banco = "012";


            PagoFactory rule = new PagoFactory();
            Pago pagocreado= rule.CrearPago(tipo, operacion, valor, cuenta, banco);

            Assert.Equal(DateTime.Now.ToShortDateString(), pagocreado.FechaRegistro.ToShortDateString());
        }
    }
}
