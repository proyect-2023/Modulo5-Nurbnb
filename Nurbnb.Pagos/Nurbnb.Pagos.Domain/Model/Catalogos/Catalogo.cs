using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Catalogos
{
    public class Catalogo:AggregateRoot
    {
        public CatalogoDescripcion Descripcion { get; private set; }
        public CatalogoPorcentaje Porcentaje { get; private set; }
        public TipoCatalogo EsReserva { get; private set; }

        public Catalogo(string descripcion, int porcentaje, TipoCatalogo esReserva) 
        {
            Id=Guid.NewGuid();
            Descripcion = descripcion;
            Porcentaje = porcentaje;
            EsReserva = esReserva;
        }
        public void Editar( string descripcion, int porcentaje)
        {
            Descripcion = descripcion;
            Porcentaje = porcentaje;
        }
        private Catalogo() { }

    }
}
