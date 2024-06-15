using GestorDePaciente.Core.Application.ViewModels.Common;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Doctor;

public class DoctorViewModel : BaseVM
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Dni { get; set; }
    public string UrlProfilePicture { get; set; }
    public int DoctorOfficeId { get; set; }
    
    public DoctorOffice DoctorOffice { get; set; }
}