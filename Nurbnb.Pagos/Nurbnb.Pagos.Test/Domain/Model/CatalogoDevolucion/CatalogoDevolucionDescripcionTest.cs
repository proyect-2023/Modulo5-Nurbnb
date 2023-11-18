using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.CatalogoDevolucion
{
    public class CatalogoDevolucionDescripcionTest
    {
        [Fact]
        public void DescripcionNotEmpty()
        {
            string valorEsperado = "Hola";
            CatalogoDevolucionDescripcion rule = new CatalogoDevolucionDescripcion(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void DescripcionEmpty()
        {
            string valorEsperado = string.Empty; 

            Assert.Throws<BussinessRuleValidationException>(() => new CatalogoDevolucionDescripcion(valorEsperado));
        }
        [Fact]
        public void DescripcionImplicito()
        {
            string valorEsperado = "algo";
            CatalogoDevolucionDescripcion rule = new CatalogoDevolucionDescripcion(valorEsperado);
            string descripcion = rule;

            Assert.Equal(valorEsperado, descripcion);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            string valorEsperado = "algo";
            CatalogoDevolucionDescripcion rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Value);
        }
    }
}
