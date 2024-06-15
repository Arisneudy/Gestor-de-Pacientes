using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Domain.Entities.Office;

public class Appointment : BaseEntity
{
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public int DoctorOfficeId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public AppointmentStatus Status { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DoctorOffice DoctorOffice { get; set; }
    
    public ICollection<LabTests> LabTests { get; set; }
}

public enum AppointmentStatus
{
    PENDIENTE_CONSULTA = 1,
    PENDIENTE_RESULTADO,
    COMPLETADA,
}