using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Nurbnb.Pagos.Domain.Repositories
{
    public interface IPagoRepository: IRepository<Pago, Guid>
    {
        Task UpdateAsync(Pago pago);
    }
}
