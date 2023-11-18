using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Pagos
{
    public class PagoImporteTest
    {
        [Fact]
        public void ImporteMayorACero()
        {
            int valorEsperado = 10;
            PagoImporte rule = new PagoImporte(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void ImporteMenorACero()
        {
            int valorEsperado = -8;

            Assert.Throws<ValorNotNegativeException>(() => new PagoImporte(valorEsperado));
        }
        [Fact]
        public void ImporteImplicito()
        {
            decimal valorEsperado = 7;
            PagoImporte rule = new PagoImporte(valorEsperado);
            Decimal importe = rule;

            Assert.Equal(valorEsperado, importe);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            decimal valorEsperado = 7;
            PagoImporte rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Value);
        }
    }
}
