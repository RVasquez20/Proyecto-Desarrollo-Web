using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;

namespace WebApplication1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "¿Recordar este explorador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }
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

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Usuario")]
        public string User { get; set; }
    }

    public class Usuarios
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public int id_rol { get; set; }
    }

    public class Roles
    {
        public int id_rol { get; set; }
        public string ROL { get; set; }

    }
    public class RolesViewModel
    {
        public int id_rol { get; set; }
        public string ROL { get; set; }

    }
    public class RolesAccess{
        public int idRolesAccess { get; set; }
        public int IdRol { get; set; }
        public int IdAccess { get; set; }
     }

    public class Access
    {
        public int IdAccess { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
    public class UsuariosViewModel
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public int id_rol { get; set; }
        public string nombreRol { get; set; }
    }
}
