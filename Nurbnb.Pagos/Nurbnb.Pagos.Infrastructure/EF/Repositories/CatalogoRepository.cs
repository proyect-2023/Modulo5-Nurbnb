using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nurbnb.Pagos.Infrastructure.EF.Contexts;

namespace Nurbnb.Pagos.Infrastructure.EF.Repositories
{
    internal class CatalogoRepository : ICatalogoRepository
    {
        private readonly WriteDbContext _context;

        public CatalogoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Catalogo obj)
        {
            await _context.Catalogo.AddAsync(obj);
        }

        public  async Task<Catalogo?> FindByIdAsync(Guid id)
        {
            return await _context.Catalogo.
                SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Catalogo catalogo)
        {
            throw new NotImplementedException();
        }
    }
}
