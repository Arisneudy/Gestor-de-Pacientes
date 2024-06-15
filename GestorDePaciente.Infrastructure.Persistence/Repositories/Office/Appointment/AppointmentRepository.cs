using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Appointment;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;

namespace GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Appointment;

public class AppointmentRepository : GenericRepository<Core.Domain.Entities.Office.Appointment>, IAppointmentsRepository
{
    private readonly ApplicationContext _context;
    
    public AppointmentRepository(ApplicationContext context) : base(context)
    {
        _context = context;
    }
    
}