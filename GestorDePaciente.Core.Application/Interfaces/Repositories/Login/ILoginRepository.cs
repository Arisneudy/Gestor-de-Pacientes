using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Domain.Entities.Login;

namespace GestorDePaciente.Core.Application.Interfaces.Repositories.Login;

public interface ILoginRepository : IGenericRepository<User>
{
     Task<User> LoginAsync(LoginViewModel vm);
     Task<User> GetByUserNameAsync(string userName);
     
}