﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{

    public abstract class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "La propiedad Nombre es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de Nombre es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de Nombre es de 2 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "La propiedad Nombre solo admite letras")]
        public string Nombre { get; set; }


        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "La propiedad Apellido es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de Apellido es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de Nombre es de 2 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "La propiedad Apellido solo admite letras")]
        public string Apellido { get; set; }


        //[Required(ErrorMessage = "La propiedad Dni es requerida")]
        [Display(Name = "Dni")]
        [RegularExpression("[0-9]{8}", ErrorMessage = "La propiedad Dni tiene que ser de 8 dígitos")]
        public string Dni { get; set; }


        [Display(Name = "Direcciones")]
        public List<Direccion> Direcciones { get; set; }


        //[Display(Name = "Telefonos")]
        //public List<Telefono> Telefonos { get; set; }


        //[Display(Name = "Mails")]
        //public List<Mail> Mails { get; set; }


        [Display(Name = "Rol")]
        public RolesEnum Rol { get; set; }
        
        [Display(Name = "Usuario")]
        [Required]
        [MaxLength(50, ErrorMessage = "Longitud máxima de 50 caracteres")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [ScaffoldColumn(false)]
        public byte[] Password { get; set; }


    }

}
