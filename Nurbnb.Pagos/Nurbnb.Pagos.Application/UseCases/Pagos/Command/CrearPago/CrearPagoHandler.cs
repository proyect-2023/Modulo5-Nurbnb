using MediatR;
using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago
{
    public class CrearPagoHandler : IRequestHandler<CrearPagoCommand, Guid>
    {
        private readonly IPagoFactory _pagoFactory;
        private readonly IPagoRepository _pagoRepository;
        private readonly ICatalogoRepository _catalogoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPagoHandler(IPagoFactory pagoFactory, IPagoRepository pagoRepository, ICatalogoRepository catalogoRepository, IUnitOfWork unitOfWork)
        {
            _pagoFactory = pagoFactory;
            _pagoRepository = pagoRepository;
            _catalogoRepository = catalogoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPagoCommand request, CancellationToken cancellationToken)
        {
            decimal importe = 1000;
            Pago pago = _pagoFactory.CrearPago(1, request.OperacionId, importe, request.PropiedadId.ToString(), "1234");
            

            //foreach (var item in request.Detalle)
            //{
                Catalogo? storedCatalogo = await _catalogoRepository.FindByIdAsync(request.CatalogoId);
                
                if (storedCatalogo == null)
                {
                    throw new PagoCreacionException(" El catálogo con ID: " + request.CatalogoId + " no existe");
                }

                if (pago !=null ) pago.AgregarDetallePago(request.CatalogoId, storedCatalogo.Porcentaje, importe);
           // }


            if (pago != null)
            {
                pago.Confirmar();
                await _pagoRepository.CreateAsync(pago);
            }


            await _unitOfWork.Commit();

            return (pago != null ? pago.Id : Guid.NewGuid());
        }
    }
}
