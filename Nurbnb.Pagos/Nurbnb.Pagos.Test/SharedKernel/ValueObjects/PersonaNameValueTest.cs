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
    public class PersonaNameValueTest
    {
        [Fact]
        public void NombreCorrecto()
        {
            string valorEsperado = "Ana";
            PersonNameValue rule = new PersonNameValue(valorEsperado);

            Assert.Equal(valorEsperado, rule.Name);
        }
        [Fact]
        public void NombreIncorrecto()
        {
            string valorEsperado = "A";

            Assert.Throws<BussinessRuleValidationException>(() => new PersonNameValue(valorEsperado));
        }
        [Fact]
        public void NombreImplicito()
        {
            string valorEsperado = "Maria";
            PersonNameValue rule = new PersonNameValue(valorEsperado);
            string nombre = rule;

            Assert.Equal(valorEsperado, nombre);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            string valorEsperado = "Maria";
            PersonNameValue rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Name);
        }
    }
}
