using GestorDePaciente.Core.Application.ViewModels.Common;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Application.ViewModels.Lab.Result;

public class ResultTestViewModel : BaseVM
{
    public string Result { get; set; }
    public ResultLabTestStatus Status { get; set; }
    public int IdLabTest { get; set; }
}