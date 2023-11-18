using Moq;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using Nurbnb.Pagos.Application.UseCases.MedioPagos.EventHandlers;
using Nurbnb.Pagos.Domain.Events;
using Xunit.Abstractions;
using static Nurbnb.Pagos.Domain.Events.PagoConfirmado;
using Nurbnb.Pagos.Domain.Exceptions;

namespace Nurbnb.Pagos.Test.Application.UseCases.MedioPagos.EventHandlers
{
    public class RegistrarMedioPagoWhenPagoConfirmado_Test
    {
        Mock<IMedioPagoRepository>  _medioPagoRepository;
        Mock<IUnitOfWork> _unitOfWork;

        public RegistrarMedioPagoWhenPagoConfirmado_Test() 
        {
            _medioPagoRepository= new Mock<IMedioPagoRepository>();
            _unitOfWork= new Mock<IUnitOfWork>();
        }
        [Fact]
        public void ImporteMayorACero()
        {
            var cuenta = "123456";
            var bco = "012";
            var pagoId= Guid.NewGuid();
            var importe = 10;
            var tcs = new CancellationTokenSource(1000);
            var detalleTransaccion = new DetallePagoConfirmado(cuenta, bco, importe);



            var handler = new RegistrarMedioPagoWhenPagoConfirmado(
                 _unitOfWork.Object,
                _medioPagoRepository.Object
               
            );
           
            PagoConfirmado evento = new PagoConfirmado(
                pagoId,
                detalleTransaccion
            );
            var result= handler.Handle(evento, tcs.Token);

            Assert.Equal(result.IsFaulted, false);
        }
        [Fact]
        public void ImporteMenorACero()
        {
            var cuenta = "123456";
            var bco = "012";
            var pagoId = Guid.NewGuid();
            var importe = -10;
            var tcs = new CancellationTokenSource(1000);
            var detalleTransaccion = new DetallePagoConfirmado(cuenta, bco, importe);


            var handler = new RegistrarMedioPagoWhenPagoConfirmado(
                 _unitOfWork.Object,
                _medioPagoRepository.Object

            );

            PagoConfirmado evento = new PagoConfirmado(
                pagoId,
                detalleTransaccion
            );
            var result = handler.Handle(evento, tcs.Token);

            Assert.Equal(result.IsFaulted, true);


        }
    }
}