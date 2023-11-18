using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.SharedKernel.ValueObjects
{
    public class CantidadValueTest
    {
        [Fact]
        public void CantidadMayorACero()
        {
            int valorEsperado = 10;
            CantidadValue rule = new CantidadValue(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }

        [Fact]
        public void CantidadMenorACero()
        {
            int valorEsperado = -10;

            Assert.Throws<BussinessRuleValidationException>(() => new CantidadValue(valorEsperado));
        }

        [Fact]
        public void CantidadImplicito()
        {
            int valorEsperado = 7;
            CantidadValue rule = new CantidadValue(valorEsperado);
            int cantidad = rule;

            Assert.Equal(valorEsperado, cantidad);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            int valorEsperado = 7;
            CantidadValue rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Value);
        }

    }
}
