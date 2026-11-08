using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Services
{
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository _actividadRepository;
        public ActividadService(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        public async Task ActualizarAsync(Actividad actividad)
        {
            await _actividadRepository.ActualizarAsync(actividad);
        }

        public async Task AgregarAsync(Actividad actividad)
        {
            await _actividadRepository.AgregarAsync(actividad);
        }

        public async Task EliminarAsync(int id)
        {
            await _actividadRepository.EliminarAsync(id);
        }

        public async Task<Actividad?> ObtenerPorIdAsync(int id)
        {
            return await _actividadRepository.ObtenerPorIdAsync(id);
        }

        public async Task<List<Actividad>> ObtenerTodosAsync()
        {
            return await _actividadRepository.ObtenerTodosAsync();
        }
    }
}
