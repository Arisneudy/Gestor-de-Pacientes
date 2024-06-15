using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Doctor;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Doctor;

public class DoctorRepository : GenericRepository<Core.Domain.Entities.Office.Doctor>, IDoctorRepository
{
    private readonly ApplicationContext _context;
    
    public DoctorRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

}