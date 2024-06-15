using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Office;

public class SaveDoctorOfficeViewModel : BaseVM
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "La dirección es requerida")]
    [DataType(DataType.Text)]
    public string? Address { get; set; }
}