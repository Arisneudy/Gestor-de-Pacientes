using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Patient;

public class PatientRepository : GenericRepository<Core.Domain.Entities.Office.Patient>, IPatientRepository
{
    private readonly ApplicationContext _context;
    
    public PatientRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Core.Domain.Entities.Office.Patient>> GetByDni(string cedula)
    {
        var query = from p in _context.Patients
            where p.Dni == cedula
            select p;
        return await query.ToListAsync();
    }
    
}