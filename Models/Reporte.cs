using System.ComponentModel.DataAnnotations;
namespace printSmart.Models
{
    public class Reporte
    {
        [Key]
        public int Id { get; set; }
    }
    public class ReporteServicioss
    {
        public string? Nombre;
        public string? Descripcion;
        public string? Tipo;
        public string? Cliente;
        public DateTime? Fecha;
        public float? Monto;
        public bool? Estado;
    }

    public class ReporteCliente
    {
        public string? Nombre;
        public string? Descripcion;
        public string? Tipo;
        public string? Cliente;
        public DateTime? Fecha;
        public bool? Estado;
    }
}
