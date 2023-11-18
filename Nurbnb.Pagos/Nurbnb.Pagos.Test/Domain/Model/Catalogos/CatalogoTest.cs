using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Catalogos
{
    public class CatalogoTest
    {
        [Fact]
        public void CrearCatalogo()
        {
            string descripcion = "descripcion de catalogo";
            int porcentaje = 50;
            TipoCatalogo tipo = TipoCatalogo.Reserva;

            Catalogo catalogo = new Catalogo(descripcion,porcentaje,tipo);


            Assert.Equal(descripcion, catalogo.Descripcion);
            Assert.Equal(porcentaje, catalogo.Porcentaje.Value);
            Assert.Equal(tipo, catalogo.EsReserva);
           
        }
        [Fact]
        public void EditarCatalogo()
        {
            string descripcion = "descripcion de catalogo";
            string nuevaDescripcion = "descripcion de catalogo nueva";
            int porcentaje = 50;
            int nuevoPorcentaje = 250;
            TipoCatalogo tipo = TipoCatalogo.Reserva;

            Catalogo catalogo = new Catalogo(descripcion, porcentaje, tipo);

            catalogo.Editar(nuevaDescripcion, nuevoPorcentaje);

            Assert.Equal(nuevaDescripcion, catalogo.Descripcion);
            Assert.Equal(nuevoPorcentaje, catalogo.Porcentaje.Value);

        }
    }
}
