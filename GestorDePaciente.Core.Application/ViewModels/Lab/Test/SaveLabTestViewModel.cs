using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Lab.Test;

public class SaveLabTestViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int IdDoctorOffice { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int IdPatient { get; set; }
}