namespace Dominio.Entidades
{
    public class Actividad
    {
        public int ActividadId { get; set; }

        public int ViajeId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public bool Completada { get; set; }
        public Viaje? Viaje { get; set; }
    }
}
