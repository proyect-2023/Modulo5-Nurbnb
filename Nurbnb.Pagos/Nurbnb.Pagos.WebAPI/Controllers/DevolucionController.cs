using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurbnb.Pagos.Application.Dto.CatalogoDevolucion;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Command.CrearDevolucion;
using Nurbnb.Pagos.Application.UseCases.Devoluciones.Query.GetDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago;
using Nurbnb.Pagos.Domain.Model.CatalogoDevolucion;

namespace Nurbnb.Pagos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DevolucionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearDevolucion([FromBody] CrearDevolucionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> BuscarDevolucion(string? searchTerm = "")
        {
            var items = await _mediator.Send(new GetDevolucionListQuery()
            {
                SearchTerm = searchTerm ?? ""
            });

            return Ok(items);
        }
    }
}
