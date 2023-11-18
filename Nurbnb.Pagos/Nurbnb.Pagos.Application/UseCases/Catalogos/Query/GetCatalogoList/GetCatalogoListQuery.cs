using MediatR;
using Nurbnb.Pagos.Application.Dto.Catalogo;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Catalogos.Query.GetCatalogoList
{
    public class GetCatalogoListQuery: IRequest<ICollection<CatalogoDto>>
    {
        public string SearchTerm { get; set; }
    }
}
