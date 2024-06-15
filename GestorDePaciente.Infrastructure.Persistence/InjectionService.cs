using GestorDePaciente.Core.Application.Interfaces.Repositories.General;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Lab;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Login;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Appointment;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Doctor;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Patient;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Role;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Users;
using GestorDePaciente.Infrastructure.Persistence.Contexts;
using GestorDePaciente.Infrastructure.Persistence.Repositories.General;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Lab;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Login;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Appointment;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Doctor;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Office.DoctorOffice;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Office.Patient;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Role;
using GestorDePaciente.Infrastructure.Persistence.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDePaciente.Infrastructure.Persistence;

public static class InjectionService
{
    public static void AddPersistenceLayer(this IServiceCollection service, IConfiguration configuration)
    {
        // Conexion a la base de datos
        service.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GestorDePacienteConnection"));
        });

        service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        service.AddTransient<IUserRepository, UserRepository>();    
        service.AddTransient<ILoginRepository, LoginRepository>();
        service.AddTransient<IRoleRepository, RoleRepository>();
        service.AddTransient<IAppointmentsRepository, AppointmentRepository>();
        service.AddTransient<IDoctorOfficeRepository, DoctorOfficeRepository>();
        service.AddTransient<IDoctorRepository, DoctorRepository>();
        service.AddTransient<IPatientRepository, PatientRepository>();
        service.AddTransient<IResultTestRepository, ResultLabTestRespository>();
        service.AddTransient<ILabTestRepository, LabTestRespository>();
        
        // Aplicar migraciones de forma automática
        using var servicesScope = service.BuildServiceProvider().CreateScope();
        var dbContext = servicesScope.ServiceProvider.GetRequiredService<ApplicationContext>();
        dbContext.Database.Migrate();
    }
}