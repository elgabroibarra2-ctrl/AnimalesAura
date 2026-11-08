using Dominio.Enum;

namespace Dominio.Entidades
{
    public class Viaje
    {
        public int ViajeId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string CiudadDestino { get; set; } = string.Empty;

        public string PaisDestino { get; set; } = string.Empty;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public decimal Presupuesto { get; set; }

        public EstadoViaje Estado { get; set; }

        public ICollection<Actividad> Actividades { get; set; } = new List<Actividad>();

        public ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
    }
}
