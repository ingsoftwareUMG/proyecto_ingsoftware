using System.ComponentModel.DataAnnotations;
namespace printSmart.Models
{
    public class ServicioRepuestoDetalle
    {
        public int Id;
        public string? Servicio;
        public string? Repuesto;
    }
    public class ServicioRepuesto
    {

        [Key]
        public long Id { get; set; }
        public long? IdRepuesto { get; set; }
        public long? IdServicio { get; set; }
        public bool Estado { get; set; }

        public virtual Servicio? IdServicioNavigarion { get; set; }
        public virtual Repuesto? IdRepuestoNavigation { get; set; }
    }
}
