using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.CatalogoDevolucion
{
    public record CatalogoDevolucionPorcentaje: ValueObject
    {
        public int Value { get; init; }
        public CatalogoDevolucionPorcentaje(int value)
        {
            if (value < 0)
                throw new ValorNotNegativeException();

            if (value > 100)
                throw new ValorPorcentajeException();

            this.Value = value;
        }

        public static implicit operator int(CatalogoDevolucionPorcentaje porcentaje) => porcentaje.Value;
        public static implicit operator CatalogoDevolucionPorcentaje(int porcentaje) => new(porcentaje);
    }
}
