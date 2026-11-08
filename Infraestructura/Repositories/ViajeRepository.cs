using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly TravelPlaningDbContext _context;
        public ViajeRepository (TravelPlaningDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarAsync(Viaje viaje)
        {
            _context.Viajes.Update(viaje);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarAsync(Viaje viaje)
        {
            await _context.Viajes.AddAsync(viaje);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var viaje = await _context.Viajes.FirstOrDefaultAsync(v => v.ViajeId == id);
            if (viaje != null)
            {
                _context.Viajes.Remove(viaje);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Viaje?> ObtenerPorIdAsync(int id)
        {
            return await _context.Viajes.AsNoTracking().FirstOrDefaultAsync(v => v.ViajeId == id);
        }

        public async Task<List<Viaje>> ObtenerTodosAsync()
        {
            return await _context.Viajes.ToListAsync();
        }
    }
}
