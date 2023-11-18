using MediatR;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Application.Dto.Catalogo;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Query.GetCatalogoList;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.UseCases.Catalogo.Query
{
    internal class GetCatalogoListHandler:
        IRequestHandler<GetCatalogoListQuery, ICollection<CatalogoDto>>
    {
        private readonly DbSet<CatalogoReadModel> _catalogo;

        public GetCatalogoListHandler(ReadDbContext context)
        {
            _catalogo = context.Catalogo;
        }

        public async Task<ICollection<CatalogoDto>> Handle(GetCatalogoListQuery request, CancellationToken cancellationToken)
        {
            var query = _catalogo.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.Descripcion.Contains(request.SearchTerm));
            }

            return await query.Select(item =>
                new CatalogoDto
                {
                    CatalogoId = item.Id,
                    Descripcion = item.Descripcion,
                    Porcentaje = item.Porcentaje,
                    Tipo= (item.EsReserva== (int)TipoCatalogo.Reserva? TipoCatalogo.Reserva.ToString():TipoCatalogo.Cobro.ToString())
                }).ToListAsync(cancellationToken);
        }
    }
}
