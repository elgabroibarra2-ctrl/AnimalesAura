using Dominio.Entidades;
namespace Aplicacion.Interfaces
{
    public interface IViajeService
    {
        Task<List<Viaje>> ObtenerTodosAsync();

        Task<Viaje?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Viaje viaje);

        Task ActualizarAsync(Viaje viaje);

        Task EliminarAsync(int id);
    }
}
