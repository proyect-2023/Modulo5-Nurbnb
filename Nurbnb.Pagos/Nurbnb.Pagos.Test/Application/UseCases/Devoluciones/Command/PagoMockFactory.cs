using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.Devoluciones.Command
{
    internal class PagoMockFactory
    {
        public static List<Pago> getPagos()
        {
            return new List<Pago>
            {
                 new PagoFactory().CrearPago(1, Guid.NewGuid(),100, "123456", "012"),
                 new PagoFactory().CrearPago(1, Guid.NewGuid(),1000, "1234566", "012"),
                 new PagoFactory().CrearPago(2, Guid.NewGuid(),500, "1234564", "012")
            };
        }
    }
}
