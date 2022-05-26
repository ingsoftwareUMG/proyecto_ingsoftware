using System.ComponentModel.DataAnnotations;
namespace printSmart.Models
{
    public class Repuesto
    {

        public Repuesto()
        {
            ServicioRepuesto = new HashSet<ServicioRepuesto>();
        }

        [Key]
        public long IdRepuesto { get; set; }

        public string? Nombre { get; set; }
        public float? Precio { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<ServicioRepuesto> ServicioRepuesto { get; set; }
    }
}
