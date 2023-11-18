using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Repositories
{
    internal class PagoRepository : IPagoRepository
    {
        public readonly DbSet<Pago> _pagos;

        public PagoRepository(WriteDbContext context)
        {
            _pagos = context.Pago;
        }
        public async Task CreateAsync(Pago obj)
        {
            await _pagos.AddAsync(obj);
        }

        public async Task<Pago?> FindByIdAsync(Guid id)
        {
            return await _pagos.Include("_detalle").
              SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Pago pago)
        {
            throw new NotImplementedException();
        }
    }
}
