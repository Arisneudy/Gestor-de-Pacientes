using GestorDePaciente.Core.Application.ViewModels.Common;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Patient;

public class PatientViewModel : BaseVM
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Dni { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsSmoker { get; set; }
    public bool HasAllergies { get; set; }
    public string? UrlProfilePicture { get; set; }
    public int DoctorOfficeId { get; set; }
}