using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Catalogos
{
    public record  CatalogoDescripcion:ValueObject
    {
            public string Value { get; init; }
            public CatalogoDescripcion(string value)
            {
                 CheckRule(new StringNotNullOrEmptyRule(value));
                 this.Value = value;
            }
        public static implicit operator string(CatalogoDescripcion catalogoDescripcion)=> catalogoDescripcion.Value;
        public static implicit operator CatalogoDescripcion(string catalogoDescripcion) => new(catalogoDescripcion);
    }
}
