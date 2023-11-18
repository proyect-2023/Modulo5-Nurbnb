using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.Dto.CatalogoDevolucion
{
    [ExcludeFromCodeCoverage]
    public class CatalogoDevolucionDto
    {
        public Guid CatalogoDevolucionId { get; set; }
        public string Descripcion { get; set; }
        public int NroDias { get; set; }
        public int PorcentajeDescuento { get; set; }
    }
}
