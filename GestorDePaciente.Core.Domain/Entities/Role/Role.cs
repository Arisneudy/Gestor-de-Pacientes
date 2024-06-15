using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Login;

namespace GestorDePaciente.Core.Domain.Entities.Role;

public class Role : BaseEntity
{
    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; }
}