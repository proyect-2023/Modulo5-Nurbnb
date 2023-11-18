using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.Rules;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Devoluciones
{
    public record DevolucionMotivo :ValueObject
    {
        public string Value { get; }

        public DevolucionMotivo(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            if (value.Length <10)
            {
                throw new BussinessRuleValidationException("Ingrese un motivo mayor a 10 caracteres");
            }
            Value = value;
        }

        public static implicit operator string(DevolucionMotivo value)
        {
            return value.Value;
        }

        public static implicit operator DevolucionMotivo(string value)
        {
            return new DevolucionMotivo(value);
        }
    }
}
