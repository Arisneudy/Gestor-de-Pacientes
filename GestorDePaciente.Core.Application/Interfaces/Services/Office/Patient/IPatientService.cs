using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels;
using GestorDePaciente.Core.Application.ViewModels.Office.Patient;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;

public interface IPatientService : IGenericService<SavePatientViewModel, PatientViewModel>
{
    Task<List<PatientViewModel>> GetByDni(string cedula);
}