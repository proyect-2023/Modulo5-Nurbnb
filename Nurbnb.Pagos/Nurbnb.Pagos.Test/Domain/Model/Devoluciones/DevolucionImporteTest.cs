using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Devoluciones
{
    public class DevolucionImporteTest
    {

        [Fact]
        public void ImporteMayorACero()
        {
            int valorEsperadoImporte = 20;
            int valorEsperadoPorcentaje = 20;
            DevolucionImporte rule = new DevolucionImporte(valorEsperadoImporte,valorEsperadoPorcentaje);

            Assert.Equal(valorEsperadoImporte, rule.Importe);
        }
        [Fact]
        public void ImporteNegativo()
        {
            int valorEsperadoImporte = -10;
            int valorEsperadoPorcentaje = 20;

            Assert.Throws<ValorNotNegativeException>(() => new DevolucionImporte(valorEsperadoImporte, valorEsperadoPorcentaje));
        }

        [Fact]
        public void PorcentajeMayorACero()
        {
            int valorEsperadoImporte = 20;
            int valorEsperadoPorcentaje = 30;
            DevolucionImporte rule = new DevolucionImporte(valorEsperadoImporte, valorEsperadoPorcentaje);

            Assert.Equal(valorEsperadoPorcentaje, rule.Porcentaje);
        }
        [Fact]
        public void PorcentajeNegativo()
        {
            int valorEsperadoImporte = -10;
            int valorEsperadoPorcentaje = -20;

            Assert.Throws<ValorNotNegativeException>(() => new DevolucionImporte(valorEsperadoImporte, valorEsperadoPorcentaje));
        }

        [Fact]
        public void CalculoDevolucionCorrecto()
        {
            int valorEsperado = 10;
            DevolucionImporte devolucion = new DevolucionImporte(20, 50);

            Assert.Equal(valorEsperado, devolucion.CalculoDevolucion());
        }
        [Fact]
        public void CalculoDevolucionInCorrecto()
        {
            int valorEsperado = 5;
            DevolucionImporte devolucion = new DevolucionImporte(20, 50);

            Assert.NotEqual(valorEsperado, devolucion.CalculoDevolucion());
        }
    }
}
