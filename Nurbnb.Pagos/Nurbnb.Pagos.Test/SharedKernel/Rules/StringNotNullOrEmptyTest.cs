using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.SharedKernel.Rules
{
    public class StringNotNullOrEmptyTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("cadena", true)]
        public void StringNotNull(string valorEsperado, bool resultadoEsperado)
        {
            StringNotNullOrEmptyRule rule = new StringNotNullOrEmptyRule(valorEsperado);
            bool esValido = rule.IsValid();

            Assert.Equal(resultadoEsperado, esValido);
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("algo", true)]
        public void StringNotEmpty(string valorEsperado, bool resultadoEsperado)
        {
            StringNotNullOrEmptyRule rule = new StringNotNullOrEmptyRule(valorEsperado);
            bool esValido = rule.IsValid();

            Assert.Equal(resultadoEsperado, esValido);
        }
    }
}
