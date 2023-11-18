using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Pagos
{
    public class DetallePagoTotalTest
    {
        [Fact]
        public void ImporteMayorACero()
        {
            int valorEsperadoImporte = 20;
            int valorEsperadoPorcentaje = 20;
            DetallePagoTotal rule = new DetallePagoTotal(valorEsperadoImporte, valorEsperadoPorcentaje);

            Assert.Equal(valorEsperadoImporte, rule.Importe);
        }
        [Fact]
        public void ImporteNegativo()
        {
            int valorEsperadoImporte = -10;
            int valorEsperadoPorcentaje = 20;

            Assert.Throws<ValorNotNegativeException>(() => new DetallePagoTotal(valorEsperadoImporte, valorEsperadoPorcentaje));
        }
        [Fact]
        public void PorcentajeMayorACero()
        {
            int valorEsperadoImporte = 20;
            int valorEsperadoPorcentaje = 20;
            DetallePagoTotal rule = new DetallePagoTotal(valorEsperadoImporte, valorEsperadoPorcentaje);

            Assert.Equal(valorEsperadoPorcentaje, rule.Porcentaje);
        }
        [Fact]
        public void PorcentajeNegativo()
        {
            int valorEsperadoImporte = 20;
            int valorEsperadoPorcentaje = -10;

            Assert.Throws<ValorNotNegativeException>(() => new DetallePagoTotal(valorEsperadoImporte, valorEsperadoPorcentaje));
        }

        [Fact]
        public void CalculoImporteCorrecto()
        {
            int valorEsperado = 10;
            DetallePagoTotal detalle = new DetallePagoTotal(20, 50);

            Assert.Equal(valorEsperado, detalle.CalculoTotal());
        }
        [Fact]
        public void CalculoDevolucionInCorrecto()
        {
            int valorEsperado = 5;
            DetallePagoTotal detalle = new DetallePagoTotal(20, 50);

            Assert.NotEqual(valorEsperado, detalle.CalculoTotal());
        }
    }
}
