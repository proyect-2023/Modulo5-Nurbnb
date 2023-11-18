using Nurbnb.Pagos.Domain.Model.Catalogos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Repositories
{
    public interface ICatalogoRepository : IRepository<Catalogo, Guid>
    {
        Task UpdateAsync(Catalogo catalogo);
    }
}
