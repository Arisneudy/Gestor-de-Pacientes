using GestorDePaciente.Core.Application.Interfaces.Repositories.Lab;
using GestorDePaciente.Core.Domain.Entities.Lab;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Lab;

public class LabTestRespository : GenericRepository<LabTests>, ILabTestRepository
{
    private readonly ApplicationContext _context;
    
    public LabTestRespository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
}