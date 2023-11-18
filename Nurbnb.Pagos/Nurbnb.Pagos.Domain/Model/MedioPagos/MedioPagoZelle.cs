using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.MedioPagos
{
    public class MedioPagoZelle : IMedioPago
    {
        public string ProcesarPago()
        {
            Random random = new Random();

            return TipoMedio.Zelle.ToString() + random.Next(10000).ToString();
        }
    }
}
