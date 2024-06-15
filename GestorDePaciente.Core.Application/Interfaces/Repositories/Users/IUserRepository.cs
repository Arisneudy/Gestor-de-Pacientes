using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Core.Domain.Entities.Login;

namespace GestorDePaciente.Core.Application.Interfaces.Repositories.Users;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByUserNameAsync(string userName);
}