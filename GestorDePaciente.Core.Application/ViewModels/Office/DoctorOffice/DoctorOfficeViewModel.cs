using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Office;

public class DoctorOfficeViewModel : BaseVM
{
    public string Name { get; set; }
    public string? Address { get; set; }
}