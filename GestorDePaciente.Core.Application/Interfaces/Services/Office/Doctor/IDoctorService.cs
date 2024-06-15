using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Office.Doctor;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Office.Doctor;

public interface IDoctorService : IGenericService<SaveDoctorViewModel, DoctorViewModel>
{
    
}