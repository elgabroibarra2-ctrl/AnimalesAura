using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IActividadService
    {
        Task<List<Actividad>> ObtenerTodosAsync();

        Task<Actividad?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Actividad actividad);

        Task ActualizarAsync(Actividad actividad);

        Task EliminarAsync(int id);
    }
}
