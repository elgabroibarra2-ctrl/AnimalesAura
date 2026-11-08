using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Services
{
    public class GastoService : IGastoService
    {
        private readonly IGastoRepository _gastoRepository;

        public GastoService(IGastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }

        public async Task<List<Gasto>> ObtenerTodosAsync()
        {
            return await _gastoRepository.ObtenerTodosAsync();  
        }

        public async Task<Gasto?> ObtenerPorIdAsync(int id)
        {
            return await _gastoRepository.ObtenerPorIdAsync(id);
        }

        public async Task AgregarAsync(Gasto gasto)
        {
            await _gastoRepository.AgregarAsync(gasto);
        }
        public async Task ActualizarAsync(Gasto gasto)
        {
            await _gastoRepository.ActualizarAsync(gasto);
        }

        public async Task EliminarAsync(int id)
        {
            await _gastoRepository.EliminarAsync(id);
        }
    }
}
