using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Role;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Role;

public interface IRoleService : IGenericService<SaveRoleViewModel, RoleViewModel>
{
    
}