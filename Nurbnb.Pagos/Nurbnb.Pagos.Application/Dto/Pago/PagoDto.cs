using Nurbnb.Pagos.Domain.Model.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.Dto.Pago
{
    public class PagoDto
    {
        public Guid PagoId { get; set; }
        public DateTime FechaRegistro { get;  set; }
        public DateTime? FechaCancelacion { get;  set; }
        public string TipoPago { get;  set; }
        public Guid OperacionId { get;  set; }
        public Decimal CostoTotalRenta { get;  set; }
        public string Estado { get;  set; }
        public string CuentaOrigen { get;  set; }
        public string BcoOrigen { get;  set; }
        public object Detalle { get; set; }
    }
}
