using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Repositories
{
    public interface IDevolucionRepository: IRepository<Devolucion, Guid>
    {
        Task UpdateAsync(Devolucion pago);
    }
}
