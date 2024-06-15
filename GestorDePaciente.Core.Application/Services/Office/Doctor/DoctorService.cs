using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Doctor;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Doctor;
using GestorDePaciente.Core.Application.ViewModels.Office.Doctor;
using GestorDePaciente.Core.Application.ViewModels.Users;

namespace GestorDePaciente.Core.Application.Services.Office.Doctor;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    
    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    public async Task<SaveDoctorViewModel> Add(SaveDoctorViewModel vm)
    {
        Domain.Entities.Office.Doctor doctor = new()
        {
            Name = vm.Name,
            LastName = vm.LastName,
            Email = vm.Email,
            PhoneNumber = vm.PhoneNumber,
            Dni = vm.Dni,
            IdDoctorOffice = vm.DoctorOfficeId,
            UrlProfilePicture = vm.UrlProfilePicture
        };
            
        doctor = await _doctorRepository.AddAsync(doctor);
        
        SaveDoctorViewModel dvm = new();
        dvm.Id = doctor.Id;
        dvm.Name = doctor.Name;
        dvm.LastName = doctor.LastName;
        dvm.Email = doctor.Email;
        dvm.PhoneNumber = doctor.PhoneNumber;
        dvm.Dni = doctor.Dni;
        dvm.DoctorOfficeId = doctor.IdDoctorOffice;
        dvm.UrlProfilePicture = doctor.UrlProfilePicture;

        return dvm;
    }
    
    public async Task Update(SaveDoctorViewModel vm)
    {
        Domain.Entities.Office.Doctor doctor = await _doctorRepository.GetByIdAsync(vm.Id);
        if (doctor == null) return;

        doctor.Name = vm.Name;
        doctor.LastName = vm.LastName;
        doctor.Email = vm.Email;
        doctor.PhoneNumber = vm.PhoneNumber;
        doctor.Dni = vm.Dni;
        doctor.UrlProfilePicture = vm.UrlProfilePicture;
        
        await _doctorRepository.UpdateAsync(doctor);
    }
    
    public async Task Delete(int id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        await _doctorRepository.DeleteAsync(doctor);
    }
    
    public async Task<SaveDoctorViewModel> GetByIdViewModel(int id)
    {
        Domain.Entities.Office.Doctor doctor = await _doctorRepository.GetByIdAsync(id);
        if (doctor == null) return null;

        SaveDoctorViewModel doctorVm = new()
        {
            Id = doctor.Id,
            Name = doctor.Name,
            LastName = doctor.LastName,
            Email = doctor.Email,
            PhoneNumber = doctor.PhoneNumber,
            Dni = doctor.Dni,
            DoctorOfficeId = doctor.IdDoctorOffice,
            UrlProfilePicture = doctor.UrlProfilePicture
        };

        return doctorVm;
    }
    
    public async Task<List<DoctorViewModel>> GetAllViewModel()
    {
        List<Domain.Entities.Office.Doctor> doctor = await _doctorRepository.GetAllAsync();
        List<DoctorViewModel> doctorVms = new();

        foreach (var doctorVm in doctor)
        {
            DoctorViewModel doctorVmss = new()
            {
                Id = doctorVm.Id,
                Name = doctorVm.Name,
                LastName = doctorVm.LastName,
                Email = doctorVm.Email,
                PhoneNumber = doctorVm.PhoneNumber,
                Dni = doctorVm.Dni,
                DoctorOfficeId = doctorVm.IdDoctorOffice,
                UrlProfilePicture = doctorVm.UrlProfilePicture
            };

            doctorVms.Add(doctorVmss);
        }

        return doctorVms;
    }
}