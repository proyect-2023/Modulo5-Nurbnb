using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Domain.Model.Devoluciones
{
    public class DevolucionMotivoTest
    {
        [Fact]
        public void MotivoMayorADiez()
        {
            string valorEsperado = "motivo esperado";
            DevolucionMotivo rule = new DevolucionMotivo(valorEsperado);

            Assert.Equal(valorEsperado, rule.Value);
        }
        [Fact]
        public void MotivoMenorADiez()
        {
            string valorEsperado = "motivo";

            Assert.Throws<BussinessRuleValidationException>(() => new DevolucionMotivo(valorEsperado));
        }
        [Fact]
        public void MovitoImplicito()
        {
            string valorEsperado = "es un nuevo motivo";
            DevolucionMotivo rule = new DevolucionMotivo(valorEsperado);
            string nuevoMotivo = rule;

            Assert.Equal(valorEsperado, nuevoMotivo);
        }
        [Fact]
        public void AsignacionImplicito()
        {
            string valorEsperado = "es un nuevo motivo";
            DevolucionMotivo rule1 = valorEsperado;

            Assert.Equal(valorEsperado, rule1.Value);
        }
    }
}
