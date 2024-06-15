using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Office.Appointment;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Office.Appointment;

public interface IAppointmentsService : IGenericService<SaveAppointmentViewModel, AppointmentViewModel>
{
    
}