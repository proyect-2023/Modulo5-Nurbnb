using Moq;
using Nurbnb.Pagos.Application.Dto.Catalogo;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Command.CrearDevolucion;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Repositories;
using Nurbnb.Pagos.Test.Application.UseCases.Devoluciones.Command;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Test.Application.UseCases.Catalogos.Command
{
    public class CrearCatalogoHandlerTest
    {
        Mock< ICatalogoRepository> _catalogoRepository;
        Mock<ICatalogoFactory >_catalogoFactory;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearCatalogoHandlerTest()
        {
            _catalogoRepository = new Mock<ICatalogoRepository>();
            _catalogoFactory = new Mock<ICatalogoFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }
        [Fact]
        public void CrearCatalogo()
        {

            var tcs = new CancellationTokenSource(1000);
            CrearCatalogoCommand evento = new CrearCatalogoCommand();

            evento.Descripcion = "Catalogo Reserva";
            evento.Porcentaje = 50;
            evento.Tipo = TipoCatalogo.Reserva;

            var handler = new CrearCatalogoHandler(_catalogoRepository.Object,_catalogoFactory.Object,_unitOfWork.Object);

            var result = handler.Handle(evento, tcs.Token);

            Assert.True(result.IsCompletedSuccessfully);
           

        }
    }
}
