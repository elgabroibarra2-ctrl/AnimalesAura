using Aplicacion.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace TravelPlaning.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViajeApiController : ControllerBase
    {
        private readonly IViajeService _viajeService;

        public ViajeApiController(IViajeService viajeService)
        {
            _viajeService = viajeService;
        }


        // ====================================================
        // GET: api/ViajeApi
        // ====================================================

        [HttpGet]
        public async Task<ActionResult<List<Viaje>>> ObtenerTodos()
        {
            var viajes = await _viajeService.ObtenerTodosAsync();

            return Ok(viajes);
        }


        // ====================================================
        // GET: api/ViajeApi/5
        // ====================================================

        [HttpGet("{id}")]
        public async Task<ActionResult<Viaje>> ObtenerPorId(int id)
        {
            var viaje = await _viajeService.ObtenerPorIdAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            return Ok(viaje);
        }


        // ====================================================
        // POST: api/ViajeApi
        // ====================================================

        [HttpPost]
        public async Task<ActionResult> Agregar(Viaje viaje)
        {
            await _viajeService.AgregarAsync(viaje);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = viaje.ViajeId },
                viaje
            );
        }


        // ====================================================
        // PUT: api/ViajeApi/5
        // ====================================================

        [HttpPut("{id}")]
        public async Task<ActionResult> Actualizar(
            int id,
            Viaje viaje)
        {
            if (id != viaje.ViajeId)
            {
                return BadRequest(
                    "El Id de la URL no coincide con el Id del viaje."
                );
            }

            var viajeExistente =
                await _viajeService.ObtenerPorIdAsync(id);

            if (viajeExistente == null)
            {
                return NotFound();
            }

            await _viajeService.ActualizarAsync(viaje);

            return NoContent();
        }


        // ====================================================
        // DELETE: api/ViajeApi/5
        // ====================================================

        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var viaje =
                await _viajeService.ObtenerPorIdAsync(id);

            if (viaje == null)
            {
                return NotFound();
            }

            await _viajeService.EliminarAsync(id);

            return NoContent();
        }
    }
}