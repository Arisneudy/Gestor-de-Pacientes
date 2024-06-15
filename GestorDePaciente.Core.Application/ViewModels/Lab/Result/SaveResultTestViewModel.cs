using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Application.ViewModels.Lab.Result;

public class SaveResultTestViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Result { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public ResultLabTestStatus Status { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int IdLabTest { get; set; }
}