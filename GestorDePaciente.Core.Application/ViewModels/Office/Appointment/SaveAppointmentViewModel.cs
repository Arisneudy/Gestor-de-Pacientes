using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.Enums;
using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Appointment;

public class SaveAppointmentViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    public AppointmentStatus Status { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int IdPatient { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int IdDoctor { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]
    public int DoctorOfficeId { get; set; }
}
