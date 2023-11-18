using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;

namespace Nurbnb.Pagos.Test.Domain.Model.CatalogoDevolucion
{
    public class CatalogoDevolucionTest
    {
        [Fact]
        public void CrearCatalogoDevolucion()
        {
            string descripcion = "descripcion de catalogo devolucion";
            int porcentaje = 50;
            int nroDias = 10;

            Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion catalogo = new Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion(descripcion,nroDias,porcentaje);


            Assert.Equal(descripcion, catalogo.Descripcion.Value);
            Assert.Equal(porcentaje, catalogo.PorcentajeDescuento.Value);
            Assert.Equal(nroDias, catalogo.NroDias.Value);

        }

        [Fact]
        public void BuscarCatalogo()
        {
            DateTime fechaInicio = DateTime.Now.AddDays(-2);
            DateTime fechaFin = DateTime.Now;

            List<Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion> listaCatalogos = new List<Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion> {
                                                                                                           new Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion("catalogo1",2,30),
                                                                                                            new Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion("catalogo2",10,80)};

            Nurbnb.Pagos.Domain.Model.CatalogoDevolucion.CatalogoDevolucion busqueda = listaCatalogos.First().BuscarCatalogo(listaCatalogos, fechaInicio, fechaFin);

         

            Assert.Equal("catalogo1", busqueda.Descripcion.Value);
            Assert.Equal(30, busqueda.PorcentajeDescuento.Value);

        }
    }
}
