using System.ComponentModel.DataAnnotations;
namespace printSmart.Models
{
    public class ServicioSuministroDetalle
    {
        public int Id;
        public string? Servicio;
        public string? Repuesto;
    }
    public class ServicioSuministro
    {
        [Key]
        public long Id { get; set; }
        public long? IdSuministro { get; set; }
        public long? IdServicio { get; set; }
        public bool Estado { get; set; }

        public virtual Servicio? IdServicioNavigarion { get; set; }
        public virtual Suministro? IdSuministroNavigation { get; set; }
    }
}

