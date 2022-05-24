using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace printSmart.Models
{
    public partial class Pago
    {

        [Key]
        public int IdPago { get; set; }
        [Required(ErrorMessage = "El id del servicio es obligatorio")]
        [Display(Name = "id del servicio")]
        public int IdServicio { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Valor del servicio")]
        public float? Valor { get; set; }
        
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

    }
}
