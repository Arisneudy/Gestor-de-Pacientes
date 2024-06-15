using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Lab;
using GestorDePaciente.Core.Domain.Entities.Login;

namespace GestorDePaciente.Core.Domain.Entities.Office;

public class DoctorOffice : BaseEntity
{
    public string Name { get; set; }
    public string? Address { get; set; }
    
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
    public ICollection<Patient> Patients { get; set; }
    public ICollection<LabTests> LabTests { get; set; }
}