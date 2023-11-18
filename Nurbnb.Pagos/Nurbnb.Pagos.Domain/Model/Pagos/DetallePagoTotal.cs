using Nurbnb.Pagos.Domain.Exceptions;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Pagos
{
    public record DetallePagoTotal : ValueObject
    {
        public decimal Importe { get; init; }
        public int Porcentaje { get; init; }
        public DetallePagoTotal(decimal importe, int porcentaje)
        {
            if (porcentaje < 0)
                throw new ValorNotNegativeException();

            if (importe < 0)
                throw new ValorNotNegativeException();

            Importe = importe;
            Porcentaje = porcentaje;
        }
        public decimal CalculoTotal()
        { 
            decimal total = Importe;
            if (Porcentaje >0)
                total = (Decimal) Importe * (Porcentaje / (Decimal)100);

            return total;

        }

       
    }
}
