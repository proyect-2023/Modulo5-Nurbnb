using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.SharedKernel.Rules
{
    public class NotNegativeRuleTest
    {
        [Theory]
        [InlineData(10, true)]
        [InlineData(-1, false)]
        public void ObjectoNotNegativo(decimal valorEsperado, bool resultadoEsperado)
        {
            NotNegativeRule rule = new NotNegativeRule(valorEsperado);
            bool esValido = rule.IsValid();

            Assert.Equal(resultadoEsperado, esValido);
        }
    }
}
