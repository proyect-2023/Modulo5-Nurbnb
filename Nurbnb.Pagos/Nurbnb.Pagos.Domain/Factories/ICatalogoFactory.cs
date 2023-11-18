using Nurbnb.Pagos.Domain.Model.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Factories
{
    public interface ICatalogoFactory
    {
        Catalogo CrearCatalogo(string descripcion, int porcentaje, int esReserva);
       
    }
}
