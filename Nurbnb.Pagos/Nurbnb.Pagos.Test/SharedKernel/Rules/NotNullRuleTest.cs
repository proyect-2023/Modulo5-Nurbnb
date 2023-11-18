using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.SharedKernel.Rules
{
    public class NotNullRuleTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData(-1, true)]
        public void ObjectoNotNull(object valorEsperado, bool resultadoEsperado)
        {
            NotNullRule rule = new NotNullRule(valorEsperado);
            bool esValido = rule.IsValid();

            Assert.Equal(resultadoEsperado, esValido);
        }
    }
}
