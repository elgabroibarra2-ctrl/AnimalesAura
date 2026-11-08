using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.Data
{
    public class TravelPlaningDbContext : DbContext
    {
        public TravelPlaningDbContext(DbContextOptions<TravelPlaningDbContext> options) : base(options)
        {

        }
        public DbSet <Viaje> Viajes { get; set; }
        public DbSet <Actividad> Actividad { get; set; }
        public DbSet <Gasto> Gastos { get; set; }
    }
}
