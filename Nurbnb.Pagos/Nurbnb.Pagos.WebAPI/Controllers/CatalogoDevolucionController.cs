using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Command.CrearCatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo;

namespace Nurbnb.Pagos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoDevolucionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogoDevolucionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCatalogo([FromBody] CrearCatalogoDevolucionCommand command)
        {
            var catalogoId = await _mediator.Send(command);

            return Ok(catalogoId);
        }
        [HttpGet]
        public async Task<IActionResult> BuscarCatalogo(string? searchTerm = "")
        {
            var items = await _mediator.Send(new GetCatalogoDevolucionListQuery()
            {
                SearchTerm = searchTerm??""
            });

            return Ok(items);
        }
        [HttpGet("ObtenerCatalogoDevolucion")]
        public async Task<IActionResult> ObtenerCatalogoDevolucion(DateTime fechaAprobacionReserva, DateTime fechaInicioEstadia)
        {
            var items = await _mediator.Send(new GetCatalogoDevolucionQuery()
            {
                FechaAprobacionReserva=fechaAprobacionReserva,
                FechaInicioEstadia=fechaInicioEstadia
            });

            return Ok(items);
        }
    }
}
