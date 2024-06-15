using System.ComponentModel.DataAnnotations;

namespace GestorDePaciente.Core.Application.ViewModels.Login;

public class LoginViewModel
{
    [Required(ErrorMessage = "Debe colocar el nombre de usuario")]
    [DataType(DataType.Text)]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Debe colocar una contraseña")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}