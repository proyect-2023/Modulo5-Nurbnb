using MediatR;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Application.Dto.Devolucion;
using Nurbnb.Pagos.Application.Dto.Pago;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Query.GetDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Pagos.Query.GetPagoList;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Nurbnb.Pagos.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.UseCases.Pago.Query
{
    internal class GetPagoListHandler:
        IRequestHandler<GetPagoListQuery, ICollection<PagoDto>>
    {
        private readonly DbSet<PagoReadModel> _pago;

        public GetPagoListHandler(ReadDbContext context)
        {
            _pago = context.Pago;
        }

        public async Task<ICollection<PagoDto>> Handle(GetPagoListQuery request, CancellationToken cancellationToken)
        {
            var query = _pago.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(x => x.OperacionId.Equals(request.SearchTerm));
            }

            return await query.Select(item =>
            new PagoDto
                {
                    PagoId=item.Id,
                    FechaRegistro=item.FechaRegistro,
                    FechaCancelacion=item.FechaCancelacion,
                    TipoPago= (item.TipoPago== (int)TipoPagos.Reserva ? TipoPagos.Reserva.ToString():TipoPagos.Cobro.ToString()),
                    OperacionId=item.OperacionId,
                    CostoTotalRenta=item.CostoTotalRenta,
                    Estado=item.Estado,
                    CuentaOrigen=item.CuentaOrigen,
                    BcoOrigen=item.BcoOrigen,
                    Detalle=  item.Detalle.Select( s =>
                       new { 
                              s.Id,
                              s.CatalogoId,
                              s.PagoId,
                              s.Porcentaje,
                              s.Total
                           }
                      
                        )
                               
                }).ToListAsync(cancellationToken);
        }
    }
}
