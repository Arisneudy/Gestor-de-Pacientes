using GestorDePaciente.Core.Application.Enums;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Appointment;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Appointment;
using GestorDePaciente.Core.Application.ViewModels.Office.Appointment;

namespace GestorDePaciente.Core.Application.Services.Office.Appointment;

public class AppointmentsService : IAppointmentsService
{
    private readonly IAppointmentsRepository _appointmentsRepository;
    
    public AppointmentsService(IAppointmentsRepository appointmentsRepository)
    {
        _appointmentsRepository = appointmentsRepository;
    }
    
    public async Task<SaveAppointmentViewModel> Add(SaveAppointmentViewModel vm)
    {
        Domain.Entities.Office.AppointmentStatus convertedStatus = (Domain.Entities.Office.AppointmentStatus)(int)vm.Status;
        
        Domain.Entities.Office.Appointment a = new()
        {
            Description = vm.Description,
            Date = vm.Date,
            IdPatient = vm.IdPatient,
            IdDoctor = vm.IdDoctor,
            Status = convertedStatus,
        };
            
        await _appointmentsRepository.AddAsync(a);
            
        return vm;
    }
    
    public async Task Update(SaveAppointmentViewModel vm)
    {
        Domain.Entities.Office.AppointmentStatus convertedStatus = (Domain.Entities.Office.AppointmentStatus)(int)vm.Status;
        Domain.Entities.Office.Appointment a = await _appointmentsRepository.GetByIdAsync(vm.Id);
        if (a == null) return;

        a.Description = vm.Description;
        a.Date = vm.Date;
        a.IdPatient = vm.IdPatient;
        a.IdDoctor = vm.IdDoctor;
        a.Status = convertedStatus;
        
        await _appointmentsRepository.UpdateAsync(a);
    }
    
    public async Task Delete(int id)
    {
        var a = await _appointmentsRepository.GetByIdAsync(id);
        await _appointmentsRepository.DeleteAsync(a);
    }
    
    public async Task<SaveAppointmentViewModel> GetByIdViewModel(int id)
    {
        Domain.Entities.Office.Appointment a = await _appointmentsRepository.GetByIdAsync(id);
        var convertedStatus = (GestorDePaciente.Core.Application.Enums.AppointmentStatus)(int)a.Status;
        if (a == null) return null;

        SaveAppointmentViewModel aVm = new()
        {
            Id = a.Id,
            Description = a.Description,
            Date = a.Date,
            IdPatient = a.IdPatient,
            IdDoctor = a.IdDoctor,
            Status = convertedStatus,
        };

        return aVm;
    }

    public async Task<List<AppointmentViewModel>> GetAllViewModel()
    {
        List<Domain.Entities.Office.Appointment> a = await _appointmentsRepository.GetAllAsync();
        List<AppointmentViewModel> aVms = new();

        foreach (var aVm in a)
        {
            var convertedStatus = (GestorDePaciente.Core.Application.Enums.AppointmentStatus)(int)aVm.Status;
            AppointmentViewModel aVmss = new()
            {
                Id = aVm.Id,
                Description = aVm.Description,
                Date = aVm.Date,
                IdPatient = aVm.IdPatient,
                IdDoctor = aVm.IdDoctor,
                Status = convertedStatus,
            };

            aVms.Add(aVmss);
        }

        return aVms;
    }
}