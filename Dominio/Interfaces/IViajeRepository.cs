using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IViajeRepository
    {
        Task<List<Viaje>> ObtenerTodosAsync();

        Task<Viaje?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Viaje viaje);

        Task ActualizarAsync(Viaje viaje);

        Task EliminarAsync(int id);
    }
}
