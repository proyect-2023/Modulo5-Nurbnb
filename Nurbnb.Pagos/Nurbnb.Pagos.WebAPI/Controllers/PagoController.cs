using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Pagos.Command.CrearPago;
using Nurbnb.Pagos.Application.UseCases.Pagos.Query.GetPagoList;

namespace Nurbnb.Pagos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPago([FromBody] CrearPagoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> BuscarPago(string? searchTerm = "")
        {
            var items = await _mediator.Send(new GetPagoListQuery()
            {
                SearchTerm = searchTerm ?? ""
            });

            return Ok(items);
        }
    }
}
