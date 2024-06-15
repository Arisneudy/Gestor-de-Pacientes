using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Users;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Users;

public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
{
    Task<UserViewModel> GetByUserName(string userName);
}