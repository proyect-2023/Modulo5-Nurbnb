using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Factories
{
    public class CatalogoFactoryTest
    {
        [Fact]
        public void CrearCatalogo()
        {
            string descripcion = "Esta es una descripcion";
            int porcentaje = 50;
            int reserva = 1;


            CatalogoFactory rule = new CatalogoFactory();
            Catalogo catalogoCreado = rule.CrearCatalogo(descripcion, porcentaje,reserva);

            Assert.Equal(descripcion, catalogoCreado.Descripcion.Value);
        }
    }
}
