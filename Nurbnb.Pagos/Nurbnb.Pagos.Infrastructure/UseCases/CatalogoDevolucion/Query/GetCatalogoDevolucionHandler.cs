using MediatR;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucion;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.UseCases.CatalogoDevolucion.Query
{
    internal class GetCatalogoDevolucionHandler:
        IRequestHandler<GetCatalogoDevolucionQuery, CatalogoDevolucionDto>
    {
        private readonly DbSet<CatalogoDevolucionReadModel> _catalogo;

        public GetCatalogoDevolucionHandler(ReadDbContext context)
        {
            _catalogo = context.CatalogoDevolucion;
        }

        public async Task<CatalogoDevolucionDto> Handle(GetCatalogoDevolucionQuery request, CancellationToken cancellationToken)
        {
            var query = _catalogo.AsNoTracking();

            int nroDia = (request.FechaInicioEstadia - request.FechaAprobacionReserva).Days;

            if (DateTime.Now.ToShortDateString().Equals(request.FechaAprobacionReserva.ToShortDateString()))
                query = query.OrderByDescending(x => x.NroDias);
            else
                query = query.Where(x => x.NroDias >= nroDia).OrderBy(x => x.NroDias);
         

            return await query.Select(item =>
                new CatalogoDevolucionDto
                {
                    CatalogoDevolucionId = item.Id,
                    Descripcion = item.Descripcion,
                    NroDias = item.NroDias,
                    PorcentajeDescuento = item.PorcentajeDescuento
                }).FirstAsync(cancellationToken);
        }
    }
}
