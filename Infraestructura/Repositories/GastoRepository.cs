using Dominio.Entidades;
using Dominio.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly TravelPlaningDbContext _context;

        public GastoRepository(TravelPlaningDbContext context)
        {
            _context = context;
        }

        public async Task<List<Gasto>> ObtenerTodosAsync()
        {
            return await _context.Gastos
                .ToListAsync();
        }

        public async Task<Gasto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Gastos.AsNoTracking().FirstOrDefaultAsync(g =>g.GastoId == id);
        }

        public async Task AgregarAsync(Gasto gasto)
        {
            await _context.Gastos.AddAsync(gasto);

            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Gasto gasto)
        {
            _context.Gastos.Update(gasto);

            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var gasto = await _context.Gastos.FirstOrDefaultAsync(g => g.GastoId == id);

            if (gasto != null)
            {
                _context.Gastos.Remove(gasto);

                await _context.SaveChangesAsync();
            }
        }
    }
}