using GestorDePaciente.Core.Application.Interfaces.Services.Lab;
using GestorDePaciente.Core.Application.Interfaces.Services.Login;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Appointment;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Doctor;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.Interfaces.Services.Role;
using GestorDePaciente.Core.Application.Interfaces.Services.Users;
using GestorDePaciente.Core.Application.Services.Lab;
using GestorDePaciente.Core.Application.Services.Login;
using GestorDePaciente.Core.Application.Services.Office.Appointment;
using GestorDePaciente.Core.Application.Services.Office.Doctor;
using GestorDePaciente.Core.Application.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Services.Office.Patient;
using GestorDePaciente.Core.Application.Services.Role;
using GestorDePaciente.Core.Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDePaciente.Core.Application;

public static class InjectionService
{
    public static void AddApplicationLayer(this IServiceCollection service)
    {
        service.AddScoped<ILoginService, LoginService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IRoleService, RoleService>();
        service.AddScoped<IPatientService, PatientService>();
        service.AddScoped<IAppointmentsService, AppointmentsService>();
        service.AddScoped<IDoctorService, DoctorService>();
        service.AddScoped<IDoctorOfficeService, DoctorOfficeService>();
        service.AddScoped<ILabTestService, LabTestService>();
        service.AddScoped<IResultTestService, ResultTestService>();
    }
}