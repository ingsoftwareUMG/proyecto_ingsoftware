// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace printSmart.Models
{
    public partial class Maquina
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "La serie es obligatoria")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "La existencia es obligatoria")]
        public int Existencia { get; set; }

        [Required(ErrorMessage = "El precio de compra es obligatorio")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        public decimal PrecioVenta { get; set; }

        public virtual MarcaMaquina Marca { get; set; }
    }
}