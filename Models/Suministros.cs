using System.ComponentModel.DataAnnotations;
namespace printSmart.Models
{
    public partial class Suministros
    {
        public Suministros()
        {
            ServicioSuministro = new HashSet<ServicioSuministro>();
        }

        [Key]
        public long IdSuministro { get; set; }
        
        public string? Nombre { get; set; }
        public float? Precio { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<ServicioSuministro> ServicioSuministro { get; set; }
    }

}
