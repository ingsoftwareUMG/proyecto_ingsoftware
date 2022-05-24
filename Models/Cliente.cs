﻿#nullable disable
using System.ComponentModel.DataAnnotations;

namespace printSmart.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Servicio = new HashSet<Servicio>();
        }

        [Key]
        public long IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} carateres", MinimumLength = 3)]
        [Display(Name = "Nombre Cliente")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} carateres", MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El costo es obligatorio")]
        [Display(Name = "Telefono")]

        public string Telefono { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        public virtual ICollection<Servicio> Servicio { get; set; }

    }
}
