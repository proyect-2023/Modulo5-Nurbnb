using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.CatalogoDevolucion
{
    public class CatalogoDevolucionDiasTest
    {
        [Fact]
        public void NroDiasMayorACero()
        {
            int valorEsperado = 10;
            CatalogoDevolucionDias rule = new CatalogoDevolucionDias(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void NroDiasMenorACero()
        {
            int valorEsperado = -8;

            Assert.Throws<ValorNotNegativeException>(() => new CatalogoDevolucionDias(valorEsperado));
        }
    }
}
