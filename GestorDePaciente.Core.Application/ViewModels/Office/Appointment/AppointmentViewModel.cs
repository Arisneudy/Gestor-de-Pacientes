using GestorDePaciente.Core.Application.Enums;
using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Appointment;

public class AppointmentViewModel : BaseVM
{
    public string Description { get; set; }
    public AppointmentStatus Status { get; set; }
    public DateTime Date { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public int DoctorOfficeId { get; set; }
}