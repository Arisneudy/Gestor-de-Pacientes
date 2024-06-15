using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;
using GestorDePaciente.Core.Application.ViewModels.Office;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Application.ViewModels.Login;

public class RegisterViewModel : BaseVM
{
    [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar un nombre")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar un apellido")]
    [DataType(DataType.Text)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar un correo")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una oficina de doctor")]
    public int DoctorOfficeId { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar una contraseña")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
    [Required(ErrorMessage = "Debe ingresar una contraseña")]
    [DataType(DataType.Password)]
    public string RepetPassword { get; set; }
    
    [Required(ErrorMessage = "Debe ingresar un rol")]
    public int RoleId { get; set; }
    
}