using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.EF.Repositories
{
    internal class CatalogoDevolucionRepository : ICatalogoDevolucionRepository
    {
        private readonly WriteDbContext _context;

        public CatalogoDevolucionRepository(WriteDbContext context)
        {
            _context = context;
        }

        public  async Task CreateAsync(CatalogoDevolucion obj)
        {
            await _context.CatalogoDevolucion.AddAsync(obj);
        }

        public async Task<CatalogoDevolucion?> FindByIdAsync(Guid id)
        {
            return await _context.CatalogoDevolucion.
                SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(CatalogoDevolucion catalogo)
        {
            throw new NotImplementedException();
        }
    }
}
