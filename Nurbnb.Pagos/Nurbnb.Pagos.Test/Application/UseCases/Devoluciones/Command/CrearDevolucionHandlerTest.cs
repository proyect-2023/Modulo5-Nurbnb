using Moq;
using Nurbnb.Pagos.Application.UseCases.MedioPagos.EventHandlers;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Command.CrearDevolucion;
using Nurbnb.Pagos.Domain.Events;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nurbnb.Pagos.Domain.Events.PagoConfirmado;

namespace Nurbnb.Pagos.Test.Application.UseCases.Devoluciones.Command
{
    public class CrearDevolucionHandlerTest
    {
        Mock<IDevolucionRepository> _devolucionRepository;
        Mock<IDevolucionFactory> _devolucionFactory;
        Mock<ICatalogoDevolucionRepository> _catalogoDevolucionRepository;
        Mock<IPagoRepository> _pagoRepository;
        Mock<IUnitOfWork> _unitOfWork;

       public CrearDevolucionHandlerTest()
        {
            _devolucionRepository = new Mock<IDevolucionRepository>();
           _devolucionFactory = new Mock<IDevolucionFactory>();  
           _catalogoDevolucionRepository =new  Mock<ICatalogoDevolucionRepository>();  
           _pagoRepository=new Mock<IPagoRepository>();                  
           _unitOfWork = new Mock<IUnitOfWork>();                      
        }
        [Fact]
        public void CrearDevolucionHandler()
        {
            
            var tcs = new CancellationTokenSource(1000);
            var pagos = PagoMockFactory.getPagos();
            var pago1 = pagos[0];
            var pago2 = pagos[1];
            var pago3 = pagos[2];
            var catalogos = CatalogoDevolucionMockFactory.getCatalogoDevolucion();
            var catalogo1 = catalogos[0];
            var catalogo2= catalogos[1];
            var catalogo3 = catalogos[2];
            CrearDevolucionCommand evento = new CrearDevolucionCommand();
            evento.PagoId = pago1.Id;
            evento.CatalogoDevolucionId = catalogo1.Id;

            Guid pagoId= Guid.NewGuid();
            Guid catalogoId= Guid.NewGuid();

            var devolucion = new DevolucionFactory().CrearDevolucion(pagoId, catalogoId, 30, 1000);

            _devolucionRepository.Setup(_devolucionRepository => _devolucionRepository.FindByIdAsync(devolucion.Id))
                    .ReturnsAsync(devolucion);

            _pagoRepository.Setup(_pagoRepository => _pagoRepository.FindByIdAsync(pago1.Id))
                    .ReturnsAsync(pago1);
            _pagoRepository.Setup(_pagoRepository => _pagoRepository.FindByIdAsync(pago2.Id))
                   .ReturnsAsync(pago2);
            _pagoRepository.Setup(_pagoRepository => _pagoRepository.FindByIdAsync(pago3.Id))
                   .ReturnsAsync(pago3);

            _catalogoDevolucionRepository.Setup(_catalogoDevolucionRepository => _catalogoDevolucionRepository.FindByIdAsync(catalogo1.Id))
                .ReturnsAsync(catalogo1);
            _catalogoDevolucionRepository.Setup(_catalogoDevolucionRepository => _catalogoDevolucionRepository.FindByIdAsync(catalogo2.Id))
                   .ReturnsAsync(catalogo2);
            _catalogoDevolucionRepository.Setup(_catalogoDevolucionRepository => _catalogoDevolucionRepository.FindByIdAsync(catalogo3.Id))
                   .ReturnsAsync(catalogo3);

            var handler = new CrearDevolucionHandler(_devolucionRepository.Object,_devolucionFactory.Object,
                                                     _unitOfWork.Object,_catalogoDevolucionRepository.Object,_pagoRepository.Object);

         
            var result = handler.Handle(evento, tcs.Token);


            Assert.True(result.IsCompletedSuccessfully);

            Assert.Equal(pago1.Id,evento.PagoId);
            Assert.Equal(catalogo1.Id,evento.CatalogoDevolucionId);

        }
    }
}
