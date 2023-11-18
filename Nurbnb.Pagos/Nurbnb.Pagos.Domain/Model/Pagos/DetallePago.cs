using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Pagos
{
    public class DetallePago:Entity
    {
        public Guid CatalogoId { get; private set; }
        public int Porcentaje { get; private set; }
        public PagoImporte Importe { get; private set; }
        public Decimal Total { get; private set; }


        public DetallePago(Guid catalogoid, int porcentaje,decimal importe)
        {
            Id = Guid.NewGuid();
            CatalogoId = catalogoid;
            Importe= importe;
            Porcentaje = porcentaje;
            Total= new DetallePagoTotal(importe,porcentaje).CalculoTotal();

        }
        private DetallePago() { }
    }
}
