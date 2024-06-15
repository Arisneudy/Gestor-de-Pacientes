using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Lab.Test;

public class LabTestViewModel : BaseVM
{
    public string Name { get; set; }
    public int IdDoctorOffice { get; set; }
    public int IdPatient { get; set; }
}