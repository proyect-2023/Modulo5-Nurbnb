using MediatR;
using Nurbnb.Pagos.Application.Dto.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo
{
    public class CrearCatalogoCommand:IRequest<Guid>
    {
        public TipoCatalogo Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set;}
    }
}
