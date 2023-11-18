using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.ReadModel
{
    [Table("pago")]
    internal class PagoReadModel
    {
        [Key]
        [Column("pagoId")]
        public Guid Id { get; set; }

        [Required]
        [Column("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }


        [AllowNull]
        [Column("fechaCancelacion")]
        public DateTime? FechaCancelacion { get; set; }

        [Required]
        [Column("tipo")]
        public int TipoPago { get; set; }

        [Required]
        [Column("operacionId")]
        public Guid OperacionId { get; set; }

        [Required]
        [Column("costoTotalRenta", TypeName = "decimal(18,2)")]
        public decimal CostoTotalRenta { get; set; }

        [Required]
        [Column("estado")]
        [MaxLength(25)]
        public string Estado { get; set; }

        [Required]
        [Column("cuentaOrigen")]
        [MaxLength(25)]
        public string CuentaOrigen { get; set; }

        [Required]
        [Column("bcoOrigen")]
        [MaxLength(25)]
        public string BcoOrigen { get; set; }

        public List<DetallePagoReadModel> Detalle { get; set; }
    }
}
