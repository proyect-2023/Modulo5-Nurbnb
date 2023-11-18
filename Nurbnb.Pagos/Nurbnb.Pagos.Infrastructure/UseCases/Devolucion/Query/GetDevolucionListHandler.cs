using MediatR;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Application.Dto.Catalogo;
using Nurbnb.Pagos.Application.Dto.Devolucion;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Query.GetCatalogoList;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Query.GetDevolucionList;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.UseCases.Devolucion.Query
{
    internal class GetDevolucionListHandler:
        IRequestHandler<GetDevolucionListQuery, ICollection<DevolucionDto>>
    {
        private readonly DbSet<DevolucionReadModel> _devolucion;

        public GetDevolucionListHandler(ReadDbContext context)
        {
            _devolucion= context.Devolucion;
        }

        public async Task<ICollection<DevolucionDto>> Handle(GetDevolucionListQuery request, CancellationToken cancellationToken)
        {
            var query = _devolucion.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.PagoId.Equals(request.SearchTerm));
            }

            return await query.Select(item =>
                new DevolucionDto
                {
                    DevolucionId=item.Id,
                    FechaRegistro=item.FechaRegistro,
                    PagoId=item.PagoId,
                    CatalogoDevolucionId=item.CatalogoDevolucionId,
                    PorcentajeDevolucion=item.PorcentajeDevolucion,
                    ImportePago=item.ImportePago,
                    TotalDevolucion=item.TotalDevolucion
                }).ToListAsync(cancellationToken);
        }
    }
}
