using GestorDePaciente.Core.Application.Interfaces.Repositories.Role;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Role;

public class RoleRepository : GenericRepository<Core.Domain.Entities.Role.Role>, IRoleRepository
{
    private readonly ApplicationContext _context;
    
    public RoleRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}