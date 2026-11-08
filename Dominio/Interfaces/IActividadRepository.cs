using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IActividadRepository
    {
        Task<List<Actividad>> ObtenerTodosAsync();

        Task<Actividad?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Actividad actividad);

        Task ActualizarAsync(Actividad actividad);

        Task EliminarAsync(int id);

    }
}
