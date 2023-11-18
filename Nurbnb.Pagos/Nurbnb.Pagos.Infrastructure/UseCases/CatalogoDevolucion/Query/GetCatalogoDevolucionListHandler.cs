using MediatR;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.UseCases.CatalogoDevolucion.Query
{
    internal class GetCatalogoDevolucionListHandler :
    IRequestHandler<GetCatalogoDevolucionListQuery, ICollection<CatalogoDevolucionDto>>
    {
        private readonly DbSet<CatalogoDevolucionReadModel> _catalogo;

        public GetCatalogoDevolucionListHandler(ReadDbContext context)
        {
            _catalogo = context.CatalogoDevolucion;
        }

        public async Task<ICollection<CatalogoDevolucionDto>> Handle(GetCatalogoDevolucionListQuery request, CancellationToken cancellationToken)
        {
            var query = _catalogo.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.Descripcion.Contains(request.SearchTerm));
            }

            return await query.Select(item =>
                new CatalogoDevolucionDto
                {
                    CatalogoDevolucionId = item.Id,
                    Descripcion = item.Descripcion,
                    NroDias = item.NroDias,
                    PorcentajeDescuento= item.PorcentajeDescuento
                }).ToListAsync(cancellationToken);
        }
    }
}
