using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Factories
{
    public class DevolucionFactoryTest
    {
        [Fact]
        public void CrearDevolucion()
        {
            Guid pago = Guid.NewGuid();
            Guid catalogo = Guid.NewGuid();
            decimal importe = 100;
            int porcentaje = 50;


            DevolucionFactory rule = new DevolucionFactory();
            Devolucion pagocreado = rule.CrearDevolucion(pago, catalogo, porcentaje, importe);

            Assert.Equal(DateTime.Now.ToShortDateString(), pagocreado.FechaRegistro.ToShortDateString());
        }
    }
}
