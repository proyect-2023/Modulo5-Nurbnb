using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Repositories
{
    public interface IMedioPagoRepository : IRepository<MedioPago, Guid>
    {
        Task UpdateAsync(MedioPago medio);
    }
}
