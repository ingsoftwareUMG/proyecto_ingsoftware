﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace printSmart.Models
{
    public partial class Costumer
    {
        public Costumer()
        {
            Collectionccs = new HashSet<Collectioncc>();
            Paymentccs = new HashSet<Paymentcc>();
            Servicio = new HashSet<Servicio>();
        }
          
        

        public int Id { get; set; }

        [Display(Name ="NIT del cliente")]
        public string Nit { get; set; }

        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "Se requiere un nombre valido para el registro")]
        public string Name { get; set; }

        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Correo del cliente")]
        public string Email { get; set; }

        public virtual ICollection<Collectioncc> Collectionccs { get; set; }
        public virtual ICollection<Paymentcc> Paymentccs { get; set; }
        public virtual ICollection<Servicio> Servicio { get; set; }
    }
}