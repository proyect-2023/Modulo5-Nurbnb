using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.ReadModel
{
    [Table("medioPago")]
    internal class MedioPagoReadModel
    {
        [Key]
        [Column("medioPagoId")]
        public Guid Id { get; set; }

        [Column("pagoId")]
        [Required]
        public Guid PagoId { get;  set; }

        [Column("cuentaOrigen")]
        [Required]
        [MaxLength(25)]
        public string CuentaOrigen { get;  set; }

        [Column("bcoOrigen")]
        [Required]
        [MaxLength(25)]
        public string BcoOrigen { get;  set; }

        [Column("importe", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Importe { get;  set; }

        [Column("comprobanteExterno")]
        [Required]
        [MaxLength(25)]
        public string ComprobanteExterno { get;  set; }
    }
}
