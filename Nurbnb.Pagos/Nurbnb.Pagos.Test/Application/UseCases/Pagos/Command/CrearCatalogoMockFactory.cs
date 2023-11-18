using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.Pagos.Command
{
    internal class CrearCatalogoMockFactory
    {
        public static List<Catalogo> getCatalogo()
        {
            return new List<Catalogo>
            {
                 new CatalogoFactory().CrearCatalogo("descripcion 1",30,1),
                 new CatalogoFactory().CrearCatalogo("descripcion 2",50,2),
                 new CatalogoFactory().CrearCatalogo("descripcion 3",100,2)
            };
        }
    }
}
