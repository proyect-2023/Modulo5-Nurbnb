using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Catalogos
{
    public class CatalogoDescripcionTest
    {
        [Fact]
        public void DescripcionNotEmpty()
        {
            string valorEsperado = "Descripción";
            CatalogoDescripcion rule = new CatalogoDescripcion(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void DescripcionEmpty()
        {
            string valorEsperado = string.Empty;

            Assert.Throws<BussinessRuleValidationException>(() => new CatalogoDescripcion(valorEsperado));
        }
    }
}
