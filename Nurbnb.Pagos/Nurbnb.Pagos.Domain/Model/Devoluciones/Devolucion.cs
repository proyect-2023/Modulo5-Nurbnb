using Nurbnb.Pagos.Domain.Events;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Domain.Model.Devoluciones
{
    public class Devolucion : AggregateRoot
    {
        public DateTime FechaRegistro { get; private set; }
        public Guid PagoId { get; private set; }
        public Guid CatalogoDevolucionId { get; private set; }
        public int PorcentajeDevolucion { get; private set; }
        public decimal ImportePago { get; private set; }
        public decimal TotalDevolucion { get; private set; }

        public Devolucion( Guid pagoId, Guid catalogoDevolucionId, int porcentajeDevolucion, decimal importePago)
        {
            FechaRegistro = DateTime.Now;
            PagoId = pagoId;
            CatalogoDevolucionId = catalogoDevolucionId;
            PorcentajeDevolucion= porcentajeDevolucion;
            ImportePago = importePago;
            TotalDevolucion = new DevolucionImporte(importePago, porcentajeDevolucion).CalculoDevolucion();
        }
        public void Confirmar()
        {
            if (TotalDevolucion == 0) return;

            DevolucionConfirmada.DetalleDevolucionConfirmada detalleDevolucion =
                new DevolucionConfirmada.DetalleDevolucionConfirmada(PagoId, CatalogoDevolucionId, TotalDevolucion);


            DevolucionConfirmada evento = new DevolucionConfirmada(Id, detalleDevolucion);
            AddDomainEvent(evento);
        }
        private Devolucion() { }
    }
}
