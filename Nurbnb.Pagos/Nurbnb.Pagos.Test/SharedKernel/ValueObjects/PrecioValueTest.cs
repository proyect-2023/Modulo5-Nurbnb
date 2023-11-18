using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.SharedKernel.ValueObjects
{
    public class PrecioValueTest
    {
        [Fact]
        public void PrecioMayorACero()
        {
            decimal valorEsperado = 20;
            PrecioValue rule = new PrecioValue(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void PrecioMenorACero()
        {
            decimal valorEsperado = -20;

            Assert.Throws<BussinessRuleValidationException>(() => new PrecioValue(valorEsperado));
        }
        [Fact]
        public void PrecioImplicito()
        {
            decimal valorEsperado = 50;
            PrecioValue rule = new PrecioValue(valorEsperado);
            decimal precio = rule;

            Assert.Equal(valorEsperado, precio);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            decimal valorEsperado = 50;
            PrecioValue rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Value);
        }
    }
}
