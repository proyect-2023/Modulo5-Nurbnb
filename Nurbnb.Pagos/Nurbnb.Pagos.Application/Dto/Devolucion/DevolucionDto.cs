using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.Dto.Devolucion
{
    [ExcludeFromCodeCoverage]
    public class DevolucionDto
    {
        public Guid DevolucionId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid PagoId { get;  set; }
        public Guid CatalogoDevolucionId { get;  set; }
        public int PorcentajeDevolucion { get;  set; }
        public decimal ImportePago { get;  set; }
        public decimal TotalDevolucion { get;  set; }
    }
}
