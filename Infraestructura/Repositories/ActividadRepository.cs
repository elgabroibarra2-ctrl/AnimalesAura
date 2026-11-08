using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly TravelPlaningDbContext _context;
        public ActividadRepository(TravelPlaningDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarAsync(Actividad actividad)
        {
            _context.Actividad.Update(actividad);
            await _context.SaveChangesAsync();  
        }

        public async Task AgregarAsync(Actividad actividad)
        {
            await _context.Actividad.AddAsync(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var actividad = await _context.Actividad.FirstOrDefaultAsync(a=> a.ActividadId == id);
            if (actividad != null)
            {
                _context.Actividad.Remove(actividad);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Actividad?> ObtenerPorIdAsync(int id)
        {
            return await _context.Actividad.AsNoTracking().FirstOrDefaultAsync(a => a.ActividadId == id);
        }

        public async Task<List<Actividad>> ObtenerTodosAsync()
        {
            return await _context.Actividad.ToListAsync();
        }
    }
}
