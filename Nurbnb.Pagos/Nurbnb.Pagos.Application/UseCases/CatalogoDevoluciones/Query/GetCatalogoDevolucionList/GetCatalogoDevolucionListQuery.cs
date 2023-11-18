using MediatR;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList
{
    public class GetCatalogoDevolucionListQuery: IRequest<ICollection<CatalogoDevolucionDto>>
    {
        public string SearchTerm { get; set; }
    }
}
