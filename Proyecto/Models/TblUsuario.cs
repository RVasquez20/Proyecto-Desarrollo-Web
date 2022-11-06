using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class TblUsuario
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdRol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]

        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }


    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public string Empleado { get; set; }
        public int? IdClinica { get; set; }
        public string Clinica { get; set; }
        public int? IdRol { get; set; }
        public string Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
