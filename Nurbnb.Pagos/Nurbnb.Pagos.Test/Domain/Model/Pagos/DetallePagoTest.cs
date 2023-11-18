using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Pagos
{
    public class DetallePagoTest
    {
        [Fact]
        public void CrearDetallePago()
        {
            Guid catalogo = Guid.NewGuid();
            int porcentaje = 50;
            PagoImporte importe = 100;
            decimal totalEsperado = 50;

            DetallePago detalle = new DetallePago(catalogo,porcentaje,importe);

            Assert.Equal(catalogo, detalle.CatalogoId);
            Assert.Equal(porcentaje, detalle.Porcentaje);
            Assert.Equal(importe, detalle.Importe);
            Assert.True(totalEsperado== detalle.Total);

        }
    }
}
