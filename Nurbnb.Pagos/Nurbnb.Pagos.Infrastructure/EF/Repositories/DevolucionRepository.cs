using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Repositories
{
    internal class DevolucionRepository : IDevolucionRepository
    {
        private readonly WriteDbContext _context;

        public DevolucionRepository(WriteDbContext context)
        {
            _context = context;
        }
        public  async Task CreateAsync(Devolucion obj)
        {
            await _context.Devolucion.AddAsync(obj);
        }

        public Task<Devolucion?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Devolucion pago)
        {
            throw new NotImplementedException();
        }
    }
}
