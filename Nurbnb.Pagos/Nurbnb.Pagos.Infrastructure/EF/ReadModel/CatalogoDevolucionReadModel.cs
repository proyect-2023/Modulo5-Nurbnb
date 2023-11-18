using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.ReadModel
{
    [Table("catalogoDevolucion")]
    internal class CatalogoDevolucionReadModel
    {
        [Key]
        [Column("catalogoDevolucionId")]
        public Guid Id { get; set; }

        [Column("descripcion")]
        [StringLength(250)]
        [Required]
        public string Descripcion { get; set; }

        [Column("nroDias")]
        [Required]
        public int NroDias { get; set; }

        [Column("porcentajeDescuento")]
        [Required]
        public int PorcentajeDescuento { get; set; }
    }
}
