using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.CatalogoDevolucion
{
    public record CatalogoDevolucionDescripcion:ValueObject
    {
        public string Value { get; init; }
        public CatalogoDevolucionDescripcion(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            this.Value = value;
        }
        public static implicit operator string(CatalogoDevolucionDescripcion catalogoDescripcion) => catalogoDescripcion.Value;
        public static implicit operator CatalogoDevolucionDescripcion(string catalogoDescripcion) => new(catalogoDescripcion);
    }
}
