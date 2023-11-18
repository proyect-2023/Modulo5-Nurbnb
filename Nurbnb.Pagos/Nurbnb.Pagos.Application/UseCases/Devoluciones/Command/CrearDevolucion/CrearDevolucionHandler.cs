using MediatR;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo;
using Nurbnb.Pagos.Domain.Exceptions;
using Nurbnb.Pagos.Domain.Factories;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;
using Nurbnb.Pagos.Domain.Model.Catalogos;
using Nurbnb.Pagos.Domain.Model.Devoluciones;
using Nurbnb.Pagos.Domain.Model.Pagos;
using Nurbnb.Pagos.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nurbnb.Pagos.Application.UseCases.Devoluciones.Command.CrearDevolucion
{
    public class CrearDevolucionHandler : IRequestHandler<CrearDevolucionCommand, Guid>
    {
        private readonly IDevolucionRepository _devolucionRepository;
        private readonly IDevolucionFactory _devolucionFactory;
        private readonly ICatalogoDevolucionRepository _catalogoDevolucionRepository;
        private readonly IPagoRepository _pagoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearDevolucionHandler(IDevolucionRepository devolucionRepository, IDevolucionFactory devolucionFactory, IUnitOfWork unitOfWork, ICatalogoDevolucionRepository catalogoDevolucionRepository, IPagoRepository pagoRepository)
        {
            _devolucionRepository = devolucionRepository;
            _devolucionFactory = devolucionFactory;
            _unitOfWork = unitOfWork;
            _catalogoDevolucionRepository = catalogoDevolucionRepository;
            _pagoRepository = pagoRepository;
        }

        public async Task<Guid> Handle(CrearDevolucionCommand request, CancellationToken cancellationToken)
        {
            Pago? storedPago = await _pagoRepository.FindByIdAsync(request.PagoId);

            if (storedPago == null)
            {
                throw new PagoCreacionException(" El pago con ID: " + request.PagoId + " no existe");
            }
            CatalogoDevolucion? storedCatalogo = await _catalogoDevolucionRepository.FindByIdAsync(request.CatalogoDevolucionId);

            if (storedCatalogo == null)
            {
                throw new PagoCreacionException(" El catálogo devolucion con ID: " + request.CatalogoDevolucionId + " no existe");
            }

            Devolucion devolucion= _devolucionFactory.CrearDevolucion(request.PagoId, request.CatalogoDevolucionId,  storedCatalogo.PorcentajeDescuento,storedPago.Detalle.Sum(x=> x.Total));



            //if (request.CrearYConfirmar)
            //{
            //    transaccion.Confirmar();
            //}

            await _devolucionRepository.CreateAsync(devolucion);


            await _unitOfWork.Commit();

            return (devolucion !=null ?devolucion.Id : Guid.NewGuid());
        }

       
    }
}
