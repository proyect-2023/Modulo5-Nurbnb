using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.Devoluciones.Command
{
    internal class CatalogoDevolucionMockFactory
    {
        public static List<CatalogoDevolucion> getCatalogoDevolucion()
        {
            return new List<CatalogoDevolucion>
            {
                 new CatalogoDevolucionFactory().CrearCatalogoDevolucion("descripcion 1",2,30),
                 new CatalogoDevolucionFactory().CrearCatalogoDevolucion("descripcion 2",10,50),
                 new CatalogoDevolucionFactory().CrearCatalogoDevolucion("descripcion 3",20,100)
            };
        }
    }
}
