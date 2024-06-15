using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Office;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;

public interface IDoctorOfficeService : IGenericService<SaveDoctorOfficeViewModel, DoctorOfficeViewModel>
{
    
}