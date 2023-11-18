using Nurbnb.Pagos.Domain.Exceptions;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.CatalogoDevolucion
{
    public record CatalogoDevolucionDias: ValueObject
    {
        public int Value { get; init; }
        public CatalogoDevolucionDias(int value)
        {
            if (value < 0)
                throw new ValorNotNegativeException();

            this.Value = value;
        }

        public static implicit operator int(CatalogoDevolucionDias nroDia) => nroDia.Value;
        public static implicit operator CatalogoDevolucionDias(int nroDia) => new(nroDia);
    }
}
