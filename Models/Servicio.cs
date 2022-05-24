using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace printSmart.Models
{
    public  class ServiciosDetalles
    {
        public int Id;
        public string? Nombre;
        public string? Descripcion;
        public string? Tipo;
        public string? Cliente;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Fecha;
        public string? Producto;
        
    }

    public class DetallesServicio
    {
        public int Id;
        public string? Nombre;
        public string? Descripcion;
        public string? Tipo;
        public string? Cliente;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Fecha;
        public string? Producto;
        public float? Vproducto;
        public float? Vtiposervicio;
        [Display(Name = "Viatico")]
        public float? Vviatico;
        public float? Total;
    }



    public partial class Servicio
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} carateres", MinimumLength = 3)]
        [Display(Name = "Servicio")]
        public string? Nombre { get; set; }
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }
        [Display(Name = "Viatico")]
        public double Viatico { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Display(Name = "Tipo de servicio")]
        public long? IdTipoServ { get; set; }
        [Display(Name = "Cliente")]
        public long? IdCliente { get; set; }
        [Display(Name = "Responsable")]
        public long? IdEmpleado { get; set; }
        [Display(Name = "Producto")]
        public long? IdProducto { get; set; }

        public virtual TipoServicio? IdTipoServNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual Empleado? IdEmpleadoNavigation { get; set; }
        public virtual Producto? IdProductoNavigation { get; set; }
    }
}
