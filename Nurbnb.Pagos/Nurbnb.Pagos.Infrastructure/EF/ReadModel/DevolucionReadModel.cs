using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("devolucion")]
    internal class DevolucionReadModel
    {
        [Key]
        [Column("devolucionId")]
        public Guid Id { get; set; }

        [Required]
        [Column("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [Column("pagoId")]
        public Guid PagoId { get; set; }
        public PagoReadModel Pago { get; set; }

        [Required]
        [Column("catalogoDevolucionId")]
        public Guid CatalogoDevolucionId { get; set; }
        public CatalogoDevolucionReadModel CatalogoDevolucion { get; set; }


        [Required]
        [Column("porcentajeDevolucion")]
        public int PorcentajeDevolucion { get; set; }

        [Required]
        [Column("importePago", TypeName = "decimal(18,2)")]
        public decimal ImportePago { get; set; }



        [Required]
        [Column("totalDevolucion", TypeName = "decimal(18,2)")]
        public decimal TotalDevolucion { get; set; }

        
    }
}
