﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace printSmart.Models
{
    public partial class Procesador
    {
        public Procesador()
        {
            Pcs = new HashSet<Pc>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre obligatoria")]
        [Display(Name = "Procesador")]
        public string Nombre { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; }
    }
}