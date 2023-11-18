using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Factories
{
    public class CatalogoDevolucionFactoryTest
    {
        [Fact]
        public void CrearCatalogoDevolucion()
        {
            string descripcion = "Esta es una descripcion";
            int nroDias = 10;
            int porcentaje = 50;


            CatalogoDevolucionFactory rule = new CatalogoDevolucionFactory();
            CatalogoDevolucion catalogoCreado = rule.CrearCatalogoDevolucion(descripcion, nroDias,porcentaje);

            Assert.Equal(descripcion, catalogoCreado.Descripcion.Value);
        }
      
    }
}
