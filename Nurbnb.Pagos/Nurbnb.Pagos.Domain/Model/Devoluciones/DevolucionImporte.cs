using Nurbnb.Pagos.Domain.Exceptions;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Devoluciones
{
    public record  DevolucionImporte: ValueObject
    {
        public decimal Importe { get; init; }
        public int Porcentaje { get; init; }
        public DevolucionImporte(decimal importe, int porcentaje)
        {
            if (porcentaje < 0)
                throw new ValorNotNegativeException();

            if (importe < 0)
                throw new ValorNotNegativeException();

            Importe = importe;
            Porcentaje = porcentaje;
        }
        public decimal CalculoDevolucion() => Importe * (Porcentaje /(Decimal)100);
    }
}
