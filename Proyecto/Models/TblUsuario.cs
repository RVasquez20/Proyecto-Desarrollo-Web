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
        [Display(Name = "Usuario")]

        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }

    public class UsuariosViewModel
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public string Empleado { get; set; }
        public string Rol { get; set; }
        public int? IdRol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioLoginViewModel
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdClinica { get; set; }
        public string Clinica { get; set; }
        public int? IdRol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
