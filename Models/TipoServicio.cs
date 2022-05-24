using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace printSmart.Models
{
    public partial class TipoServicio
    {

        public TipoServicio()
        {
            Servicio = new HashSet<Servicio>();
        }

        [Key]
        public long IdTipoServ { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} carateres", MinimumLength = 3)]
        [Display(Name = "Tipo Servicio" )]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} carateres", MinimumLength = 3)]
        [Display(Name ="Descripcion")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage="El costo es obligatorio")]
        [Display(Name = "Costo")]
        
        public float Costo { get; set; }
        [Required(ErrorMessage ="El estado es obligatorio")]
        [Display(Name ="Estado")]
        public bool Estado { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}
