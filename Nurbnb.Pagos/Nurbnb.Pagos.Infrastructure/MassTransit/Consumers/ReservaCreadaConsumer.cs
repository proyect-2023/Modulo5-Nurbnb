using MassTransit;
using MediatR;
using Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago;
using NurBNB.Reservas.IntegrationEvents;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Infrastructure.MassTransit.Consumers
{
    internal class ReservaCreadaConsumer : IConsumer<ReservaCreada>
    {
        private readonly IMediator _mediator;

        public ReservaCreadaConsumer(IMediator mediator) {  _mediator= mediator; }
        public  async Task Consume(ConsumeContext<ReservaCreada> context)
        {
            var message= context.Message;
            var command = new CrearPagoCommand()
            {
                  OperacionId= message.ReservaId,
                  PropiedadId=message.PropiedaId,
                  CatalogoId= Guid.NewGuid()//message.Nombre
            };
          await _mediator.Send(command);
        }   
    }
}
