using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Core.Application.ViewModels;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Patient;

public interface IPatientRepository : IGenericRepository<Domain.Entities.Office.Patient>
{
    Task<List<Domain.Entities.Office.Patient>> GetByDni(string cedula);
}