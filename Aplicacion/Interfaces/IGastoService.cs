using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Interfaces
{
    public interface IGastoService
    {
        Task<List<Gasto>> ObtenerTodosAsync();

        Task<Gasto?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Gasto gasto);

        Task ActualizarAsync(Gasto gasto);

        Task EliminarAsync(int id);
    }
}
