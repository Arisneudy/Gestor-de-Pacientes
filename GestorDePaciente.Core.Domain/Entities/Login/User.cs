using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Domain.Entities.Login;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int DoctorOfficeId { get; set; }
    public string Password { get; set; }
    
    public int RoleId { get; set; }
    public DoctorOffice DoctorOffice { get; set; }
    public Role.Role Role { get; set; }
}