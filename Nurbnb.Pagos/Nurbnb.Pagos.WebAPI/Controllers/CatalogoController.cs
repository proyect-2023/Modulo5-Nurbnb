using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nurbnb.Pagos.Application.UseCases.CatalogoDevoluciones.Query.GetCatalogoDevolucionList;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Command.CrearCatalogo;
using Nurbnb.Pagos.Application.UseCases.Catalogos.Query.GetCatalogoList;

namespace Nurbnb.Pagos.WebAPI.Controllers
{
    [Route("api/CatalogoPago")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCatalogo([FromBody] CrearCatalogoCommand command)
        {
            var catalogoId = await _mediator.Send(command);

            return Ok(catalogoId);
        }
        [HttpGet]
        public async Task<IActionResult> BuscarCatalogo(string? searchTerm = "")
        {
            var items = await _mediator.Send(new GetCatalogoListQuery()
            {
                SearchTerm = searchTerm ?? ""
            });

            return Ok(items);
        }
    }
}
