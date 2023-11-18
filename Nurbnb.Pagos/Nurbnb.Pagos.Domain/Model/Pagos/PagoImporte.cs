using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Pagos
{
    public record PagoImporte:ValueObject
    {
        public decimal Value { get; init; }
        public PagoImporte(decimal value)
        {
            if (value < 0)
                throw new ValorNotNegativeException();
            this.Value = value;
        }

        public static implicit operator decimal(PagoImporte importe) => importe.Value;
        public static implicit operator PagoImporte(decimal importe) => new PagoImporte (importe);
    }
}
