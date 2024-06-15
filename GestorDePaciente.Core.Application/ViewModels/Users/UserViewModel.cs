using GestorDePaciente.Core.Application.ViewModels.Common;
using GestorDePaciente.Core.Domain.Entities.Office;
using GestorDePaciente.Core.Domain.Entities.Role;


namespace GestorDePaciente.Core.Application.ViewModels.Users;

public class UserViewModel : BaseVM
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int DoctorOfficeId { get; set; }
    public string Password { get; set; }
    
    public int RoleId { get; set; }

    public DoctorOffice DoctorOffice { get; set; }
    public Domain.Entities.Role.Role Role { get; set; }
}