using MediatR;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Devoluciones.Command.CrearDevolucion
{
    public class CrearDevolucionCommand : IRequest<Guid>
    {
        public Guid PagoId { get;  set; }
        public Guid CatalogoDevolucionId { get; set; }
       
        //public CrearDevolucionCommand (Guid pago, Guid catalogoDevolucion)
        //{
        //    PagoId = pago;
        //    CatalogoDevolucionId = catalogoDevolucion;
        //}
    }

    

}
