using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Login;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Users;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Application.ViewModels.Users;
using GestorDePaciente.Core.Domain.Entities.Login;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationContext _context;
    
    public UserRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<User> AddAsync(User entity)
    {
        entity.Password = PasswordEncryptation.Encrypt(entity.Password);
        await base.AddAsync(entity);
        return entity;
    }
    
    public override async Task<User> UpdateAsync(User entity)
    {
        entity.Password = PasswordEncryptation.Encrypt(entity.Password);
        await base.UpdateAsync(entity);
        return entity;
    }
    
    public async Task<User> GetByUserNameAsync(string userName)
    {
        User user = await _context.Set<User>().FirstOrDefaultAsync(user => user.UserName == userName);
        return user;
    }
    
}