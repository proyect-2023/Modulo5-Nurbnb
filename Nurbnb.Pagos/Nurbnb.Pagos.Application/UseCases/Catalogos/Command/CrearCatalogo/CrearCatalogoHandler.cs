using MediatR;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo
{
    public class CrearCatalogoHandler: IRequestHandler<CrearCatalogoCommand,Guid>
    {
        private readonly ICatalogoRepository _catalogoRepository;
        private readonly ICatalogoFactory _catalogoFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCatalogoHandler(ICatalogoRepository catalogoRepository, ICatalogoFactory catalogoFactory, IUnitOfWork unitOfWork)
        {
            _catalogoRepository = catalogoRepository;
            _catalogoFactory = catalogoFactory;
            _unitOfWork = unitOfWork;
        }

        public  async Task<Guid> Handle(CrearCatalogoCommand request, CancellationToken cancellationToken)
        {
            var catalogoCreado = _catalogoFactory.CrearCatalogo(request.Descripcion, request.Porcentaje, (int)request.Tipo);
            await _catalogoRepository.CreateAsync(catalogoCreado);

            await _unitOfWork.Commit();

            return (catalogoCreado !=null? catalogoCreado.Id: Guid.NewGuid());
        }

        
    }
}
