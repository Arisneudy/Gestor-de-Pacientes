using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Application.ViewModels.Users;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Login;

public interface ILoginService : IGenericService<RegisterViewModel, UserViewModel>
{
    Task<UserViewModel> Login(LoginViewModel vm);
    Task<UserViewModel> GetByUserName(string userName);
}