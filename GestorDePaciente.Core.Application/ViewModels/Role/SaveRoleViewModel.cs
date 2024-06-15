using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Role;

public class SaveRoleViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
}