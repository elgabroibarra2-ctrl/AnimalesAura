namespace TravelPlaning.Controllers.Api
{
    using Aplicacion.Interfaces;
    using Dominio.Entidades;
    using Microsoft.AspNetCore.Mvc;

    namespace TravelPlaning.Controllers.Api
    {
        [ApiController]
        [Route("api/[controller]")]
        public class GastoApiController : ControllerBase
        {
            private readonly IGastoService _gastoService;

            public GastoApiController(
                IGastoService gastoService)
            {
                _gastoService = gastoService;
            }


            [HttpGet]
            public async Task<ActionResult<List<Gasto>>> ObtenerTodos()
            {
                var gastos =
                    await _gastoService.ObtenerTodosAsync();

                return Ok(gastos);
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<Gasto>> ObtenerPorId(int id)
            {
                var gasto =
                    await _gastoService.ObtenerPorIdAsync(id);

                if (gasto == null)
                {
                    return NotFound();
                }

                return Ok(gasto);
            }


            [HttpPost]
            public async Task<ActionResult> Agregar(Gasto gasto)
            {
                await _gastoService.AgregarAsync(gasto);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = gasto.GastoId },
                    gasto
                );
            }


            [HttpPut("{id}")]
            public async Task<ActionResult> Actualizar(
                int id,
                Gasto gasto)
            {
                if (id != gasto.GastoId)
                {
                    return BadRequest(
                        "El Id de la URL no coincide con el Id del gasto."
                    );
                }

                var gastoExistente =
                    await _gastoService.ObtenerPorIdAsync(id);

                if (gastoExistente == null)
                {
                    return NotFound();
                }

                await _gastoService.ActualizarAsync(gasto);

                return NoContent();
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult> Eliminar(int id)
            {
                var gasto =
                    await _gastoService.ObtenerPorIdAsync(id);

                if (gasto == null)
                {
                    return NotFound();
                }

                await _gastoService.EliminarAsync(id);

                return NoContent();
            }
        }
    }
}

