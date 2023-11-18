using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.Dto.Catalogo
{
    [ExcludeFromCodeCoverage]
    public class CatalogoDto
    {
        public Guid CatalogoId { get; set; }
        public string Descripcion { get;  set; }
        public int Porcentaje { get;  set; }
        public string Tipo { get;  set; }
    }
}
