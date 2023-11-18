using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.ReadModel
{
    [Table("detallePago")]
    internal class DetallePagoReadModel
    {
        [Key]
        [Column("detallePagoId")]
        public Guid Id { get; set; }

        [Required]
        [Column("catalogoId")]
        public Guid CatalogoId { get; set; }
        public CatalogoReadModel Catalogo { get; set; }

        [Required]
        [Column("pagoId")]
        public Guid PagoId { get; set; }
        public PagoReadModel Pago { get; set; }

        [Required]
        [Column("porcentaje")]
        public int Porcentaje { get; set; }

        [Required]
        [Column("importe", TypeName = "decimal(18,2)")]
        public decimal Importe { get; set; }

        [Required]
        [Column("total", TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
