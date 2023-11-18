using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Devoluciones
{
    public class DevolucionTest
    {
        [Fact]
        public void CrearDevolucion()
        {
            Decimal valorEsperadoTotal = 25;
            Guid pago = Guid.NewGuid();
            Guid catalogoDevolucion = Guid.NewGuid();
            int porcentaje = 50;
            decimal importe = 50;

            Devolucion devolucion = new Devolucion(pago,catalogoDevolucion, porcentaje,importe);
         

            Assert.Equal(valorEsperadoTotal, devolucion.TotalDevolucion);
            Assert.Equal(pago, devolucion.PagoId);
            Assert.Equal(catalogoDevolucion, devolucion.CatalogoDevolucionId);
            Assert.Equal(porcentaje, devolucion.PorcentajeDevolucion);
            Assert.Equal(importe, devolucion.ImportePago);
            Assert.Equal(DateTime.Now.ToShortDateString(), devolucion.FechaRegistro.ToShortDateString());
        }
        [Fact]
        public void ConfirmarDevolucion()
        {
            Decimal valorEsperadoTotal = 50;
            Guid pago = Guid.NewGuid();
            Guid catalogoDevolucion = Guid.NewGuid();
            int porcentaje = 50;
            decimal importe = 100;

            Devolucion devolucion = new Devolucion(pago, catalogoDevolucion, porcentaje, importe);

            devolucion.Confirmar();

            Assert.Equal(valorEsperadoTotal, devolucion.TotalDevolucion);
           
        }
    }
}
