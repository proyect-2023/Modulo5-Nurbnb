using MediatR;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Command.CrearCatalogoDevolucion
{
    public class CrearCatalogoDevolucionHandler : IRequestHandler<CrearCatalogoDevolucionCommand, Guid>
    {
        private readonly ICatalogoDevolucionRepository _catalogoDevolucionRepository;
        private readonly ICatalogoDevolucionFactory _catalogoDevolucionFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCatalogoDevolucionHandler(ICatalogoDevolucionRepository catalogoDevolucionRepository, ICatalogoDevolucionFactory catalogoDevolucionFactory, IUnitOfWork unitOfWork)
        {
            _catalogoDevolucionRepository = catalogoDevolucionRepository;
            _catalogoDevolucionFactory = catalogoDevolucionFactory;
            _unitOfWork = unitOfWork;
        }

        public  async Task<Guid> Handle(CrearCatalogoDevolucionCommand request, CancellationToken cancellationToken)
        {
            var catalogoCreado = _catalogoDevolucionFactory.CrearCatalogoDevolucion(request.Descripcion, request.NroDias, request.PorcentajeDescuento);
            await _catalogoDevolucionRepository.CreateAsync(catalogoCreado);

            await _unitOfWork.Commit();

            return (catalogoCreado !=null ?catalogoCreado.Id: Guid.NewGuid());
        }
    }
}
