using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.DoctorOffice;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Office.DoctorOffice;

public class DoctorOfficeRepository : GenericRepository<Core.Domain.Entities.Office.DoctorOffice>, IDoctorOfficeRepository
{
    private readonly ApplicationContext _context;
    
    public DoctorOfficeRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }

    
}