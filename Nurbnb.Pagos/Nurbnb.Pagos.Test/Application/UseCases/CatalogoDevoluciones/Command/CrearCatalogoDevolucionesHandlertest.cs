using Moq;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Command.CrearCatalogoDevolucion;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.CatalogoDevoluciones.Command
{
    public class CrearCatalogoDevolucionesHandlertest
    {

        Mock<ICatalogoDevolucionRepository> _catalogoDevolucionRepository;
        Mock<ICatalogoDevolucionFactory> _catalogoDevolucionFactory;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearCatalogoDevolucionesHandlertest()
        {
            _catalogoDevolucionRepository = new Mock<ICatalogoDevolucionRepository>();
            _catalogoDevolucionFactory = new Mock<ICatalogoDevolucionFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }
        [Fact]
        public void CrearCatalogoDevolucion()
        {

            var tcs = new CancellationTokenSource(1000);
            CrearCatalogoDevolucionCommand evento = new CrearCatalogoDevolucionCommand();

            evento.Descripcion = "Catalogo Devolucion";
            evento.PorcentajeDescuento = 50;
            evento.NroDias = 2;

            var handler = new CrearCatalogoDevolucionHandler(_catalogoDevolucionRepository.Object, _catalogoDevolucionFactory.Object, _unitOfWork.Object);

            var result = handler.Handle(evento, tcs.Token);

            Assert.True(result.IsCompletedSuccessfully);


        }
    }
}
