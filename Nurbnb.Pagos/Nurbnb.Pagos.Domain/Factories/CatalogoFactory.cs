using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public class CatalogoFactory : ICatalogoFactory
    {
        public Catalogo CrearCatalogo(string descripcion, int porcentaje, int esReserva)
        {
            return new Catalogo(descripcion, porcentaje, (esReserva==1? TipoCatalogo.Reserva:TipoCatalogo.Cobro));
        }

      
    }
}
