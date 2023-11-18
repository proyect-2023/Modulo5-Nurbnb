using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.ReadModel
{
    [Table("catalogo")]
    internal class CatalogoReadModel
    {
        [Key]
        [Column("catalogoId")]
        public Guid Id { get; set; }

        [Column("descripcion")]
        [StringLength(250)]
        [Required]
        public string Descripcion { get; set; }

        [Column("porcentaje")]
        [Required]
        public int Porcentaje { get;  set; }

        [Column("esReserva")]
        [Required]
        public int EsReserva { get; set; }
    }
}
