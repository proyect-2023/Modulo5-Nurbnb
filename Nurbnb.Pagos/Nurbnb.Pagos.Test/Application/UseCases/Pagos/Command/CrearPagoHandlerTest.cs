using Moq;
using Nurbnb.Pagos.Application.Dto.Pago;
using Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Test.Application.UseCases.Devoluciones.Command;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.Pagos.Command
{
    public class CrearPagoHandlerTest
    {
        Mock<IPagoFactory> _pagoFactory;
        Mock<IPagoRepository> _pagoRepository;
        Mock<ICatalogoRepository> _catalogoRepository;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearPagoHandlerTest()
        {
            _catalogoRepository = new Mock<ICatalogoRepository>();
            _pagoFactory = new Mock<IPagoFactory>();
            _pagoRepository= new Mock<IPagoRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CrearPagoHandler()
        {

            var tcs = new CancellationTokenSource(1000);
            
            var catalogos = CrearCatalogoMockFactory.getCatalogo();
            var catalogo1 = catalogos[0];
            var catalogo2 = catalogos[1];
            var catalogo3 = catalogos[2];
            CrearPagoCommand evento = new CrearPagoCommand();

            //evento.TipoPago = TipoPagos.Cobro;
            //evento.OperacionId=Guid.NewGuid();
            //evento.CostoTotalRenta = 1000;
            //evento.CuentaOrigen = "123456";
            //evento.BcoOrigen = "012";
            //evento.Detalle= new List<ItemDetallePago> { new ItemDetallePago{CatalogoId= catalogo1.Id} };


            _catalogoRepository.Setup(_catalogoRepository => _catalogoRepository.FindByIdAsync(catalogo1.Id))
                .ReturnsAsync(catalogo1);
            _catalogoRepository.Setup(_catalogoRepository => _catalogoRepository.FindByIdAsync(catalogo2.Id))
                   .ReturnsAsync(catalogo2);
            _catalogoRepository.Setup(_catalogoRepository => _catalogoRepository.FindByIdAsync(catalogo3.Id))
                   .ReturnsAsync(catalogo3);

            var handler = new CrearPagoHandler(_pagoFactory.Object,_pagoRepository.Object,_catalogoRepository.Object, 
                                                     _unitOfWork.Object);

            var result = handler.Handle(evento, tcs.Token);

            Assert.True(result.IsCompletedSuccessfully);
           
        }

    }
}
