using MediatR;
using Nurbnb.Pagos.Domain.Events;
using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Model.MedioPagos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.MedioPagos.EventHandlers
{
    public class RegistrarMedioPagoWhenPagoConfirmado
     : INotificationHandler<PagoConfirmado>
    {
        private readonly IMedioPagoRepository _medioPagoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarMedioPagoWhenPagoConfirmado(
            IUnitOfWork unitOfWork,
            IMedioPagoRepository medioPagoRepository)
        {
            _unitOfWork = unitOfWork;
            _medioPagoRepository = medioPagoRepository;
        }

        public async Task Handle(PagoConfirmado evento, CancellationToken cancellationToken)
        {
            if (evento.Detalle.totalImporte <0)
                throw new ValorNotNegativeException();

            MedioPago medio = new MedioPago(evento.Id, evento.Detalle.cuentaOrigen, evento.Detalle.bcoOrigen, evento.Detalle.totalImporte);
            medio.Pagar();

            await _medioPagoRepository.CreateAsync(medio);

            await _unitOfWork.Commit();


        }
    }
}
