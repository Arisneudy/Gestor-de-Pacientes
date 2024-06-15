using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Domain.Entities.Login;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Login;
using Microsoft.EntityFrameworkCore;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Login;

public class LoginRepository : GenericRepository<User>, ILoginRepository
{

    private readonly ApplicationContext _context;
    
    public LoginRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<User> AddAsync(User entity)
    {
        entity.Password = PasswordEncryptation.Encrypt(entity.Password);
        await base.AddAsync(entity);
        return entity;
    }
    
    public async Task<User> LoginAsync(LoginViewModel vm)
    {
        string passwordEncrypt = PasswordEncryptation.Encrypt(vm.Password);
        User user = await _context.Set<User>().FirstOrDefaultAsync(user => user.UserName == vm.UserName && user.Password == passwordEncrypt);
        return user;
    }
    
    public async Task<User> GetByUserNameAsync(string userName)
    {
        User user = await _context.Set<User>().FirstOrDefaultAsync(user => user.UserName == userName);
        return user;
    }
}