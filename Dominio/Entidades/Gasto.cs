using Dominio.Enum;
namespace Dominio.Entidades
{
    public class Gasto
    {
        public int GastoId { get; set; }

        public int ViajeId { get; set; }

        public string Concepto { get; set; } = string.Empty;

        public decimal Monto { get; set; }

        public DateTime Fecha { get; set; }

        public CategoriaGasto Categoria { get; set; }
        public Viaje? Viaje { get; set; }
    }
}
