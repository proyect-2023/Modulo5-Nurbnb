using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.CatalogoDevolucion
{
    public class CatalogoDevolucionPorcentajeTest
    {
        [Fact]
        public void PorcentajeMayorACero()
        {
            int valorEsperado = 10;
            CatalogoDevolucionPorcentaje rule = new CatalogoDevolucionPorcentaje(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void PorcentajeNegative()
        {
            int valorEsperado = -8;

            Assert.Throws<ValorNotNegativeException>(() => new CatalogoDevolucionPorcentaje(valorEsperado));
        }
        [Fact]
        public void PorcentajeMayorA100()
        {
            int valorEsperado = 101;

            Assert.Throws<ValorPorcentajeException>(() => new CatalogoDevolucionPorcentaje(valorEsperado));
        }
    }
}
