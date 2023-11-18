using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Catalogos
{
    public class CatalogoPorcentajeTest
    {
        [Fact]
        public void PorcentajeMayorACero()
        {
            int valorEsperado = 20;
            CatalogoPorcentaje rule = new CatalogoPorcentaje(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void PorcentajeNegative()
        {
            int valorEsperado = -1;

            Assert.Throws<ValorNotNegativeException>(() => new CatalogoPorcentaje(valorEsperado));
        }
    }
}
