using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Services
{
    public class ViajeService : IViajeService
    {
        private readonly IViajeRepository _viajeRepository;

        public ViajeService(IViajeRepository viajeRepository)
        {
            _viajeRepository = viajeRepository;
        }

        public async Task<List<Viaje>> ObtenerTodosAsync()
        {
            return await _viajeRepository.ObtenerTodosAsync();
        }

        public async Task<Viaje?> ObtenerPorIdAsync(int id)
        {
            return await _viajeRepository.ObtenerPorIdAsync(id);
        }

        public async Task AgregarAsync(Viaje viaje)
        {
            await _viajeRepository.AgregarAsync(viaje);
        }

        public async Task ActualizarAsync(Viaje viaje)
        {
            await _viajeRepository.ActualizarAsync(viaje);
        }

        public async Task EliminarAsync(int id)
        {
            await _viajeRepository.EliminarAsync(id);
        }
    }
}
