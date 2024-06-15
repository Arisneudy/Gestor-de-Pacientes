using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Lab.Test;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Lab;

public interface ILabTestService : IGenericService<SaveLabTestViewModel, LabTestViewModel>
{
    
}