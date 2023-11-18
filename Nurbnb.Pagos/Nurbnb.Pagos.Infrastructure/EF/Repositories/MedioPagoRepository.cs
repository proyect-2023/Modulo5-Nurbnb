using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Repositories
{
    internal class MedioPagoRepository : IMedioPagoRepository
    {
        private readonly WriteDbContext _context;

        public MedioPagoRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(MedioPago obj)
        {
            await _context.MedioPago.AddAsync(obj);
        }

        public Task<MedioPago?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MedioPago medio)
        {
            throw new NotImplementedException();
        }
    }
}
