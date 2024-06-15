using GestorDePaciente.Core.Application.Interfaces.Repositories.Lab;
using GestorDePaciente.Core.Domain.Entities.Lab;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Lab;

public class ResultLabTestRespository : GenericRepository<ResultLabTest>, IResultTestRepository
{
    private readonly ApplicationContext _context;
    
    public ResultLabTestRespository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<ResultLabTest>> GetPendingTestsByUserId(int patientId)
    {
        return await _context.ResultLabTests.Where(rt => rt.IdPatient == patientId && rt.Status == ResultLabTestStatus.PENDIENTE)
            .ToListAsync();
    }
}