namespace TravelPlaning.Controllers.Api
{
    using Aplicacion.Interfaces;
    using Dominio.Entidades;
    using Microsoft.AspNetCore.Mvc;

    namespace TravelPlaning.Controllers.Api
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ActividadApiController : ControllerBase
        {
            private readonly IActividadService _actividadService;

            public ActividadApiController(
                IActividadService actividadService)
            {
                _actividadService = actividadService;
            }


            [HttpGet]
            public async Task<ActionResult<List<Actividad>>> ObtenerTodos()
            {
                var actividades =
                    await _actividadService.ObtenerTodosAsync();

                return Ok(actividades);
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<Actividad>> ObtenerPorId(int id)
            {
                var actividad =
                    await _actividadService.ObtenerPorIdAsync(id);

                if (actividad == null)
                {
                    return NotFound();
                }

                return Ok(actividad);
            }


            [HttpPost]
            public async Task<ActionResult> Agregar(
                Actividad actividad)
            {
                await _actividadService.AgregarAsync(actividad);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = actividad.ActividadId },
                    actividad
                );
            }


            [HttpPut("{id}")]
            public async Task<ActionResult> Actualizar(
                int id,
                Actividad actividad)
            {
                if (id != actividad.ActividadId)
                {
                    return BadRequest(
                        "El Id de la URL no coincide con el Id de la actividad."
                    );
                }

                var actividadExistente =
                    await _actividadService.ObtenerPorIdAsync(id);

                if (actividadExistente == null)
                {
                    return NotFound();
                }

                await _actividadService.ActualizarAsync(actividad);

                return NoContent();
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult> Eliminar(int id)
            {
                var actividad =
                    await _actividadService.ObtenerPorIdAsync(id);

                if (actividad == null)
                {
                    return NotFound();
                }

                await _actividadService.EliminarAsync(id);

                return NoContent();
            }
        }
    }
}
