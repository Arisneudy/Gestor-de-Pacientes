using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.Patient;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels;
using GestorDePaciente.Core.Application.ViewModels.Lab.Test;
using GestorDePaciente.Core.Application.ViewModels.Office.Patient;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Application.Services.Office.Patient;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    
    public async Task<SavePatientViewModel> Add(SavePatientViewModel vm)
    {
        Domain.Entities.Office.Patient p = new()
        {
            Name = vm.Name,
            LastName = vm.LastName,
            Email = vm.Email,
            PhoneNumber = vm.PhoneNumber,
            Address = vm.Address,
            Dni = vm.Dni,
            BirthDate = vm.BirthDate,
            HasAllergies = vm.HasAllergies,
            IsSmoker = vm.IsSmoker,
            IdDoctorOffice = vm.DoctorOfficeId,
            UrlProfilePicture = vm.UrlProfilePicture,
        };
        
        p =  await _patientRepository.AddAsync(p);
        
        SavePatientViewModel svp = new();
        svp.Id = p.Id;
        svp.Name = p.Name;
        svp.LastName = p.LastName;
        svp.Email = p.Email;
        svp.PhoneNumber = p.PhoneNumber;
        svp.Address = p.Address;
        svp.Dni = p.Dni;
        svp.BirthDate = p.BirthDate;
        svp.HasAllergies = p.HasAllergies;
        svp.IsSmoker = p.IsSmoker;
        svp.DoctorOfficeId = p.IdDoctorOffice;
        svp.UrlProfilePicture = p.UrlProfilePicture;

        return svp;
    }
    
    public async Task Update(SavePatientViewModel vm)
    {
        Domain.Entities.Office.Patient p = await _patientRepository.GetByIdAsync(vm.Id);
        if (p == null) return;

        p.Name = vm.Name;
        p.LastName = vm.LastName;
        p.Email = vm.Email;
        p.PhoneNumber = vm.PhoneNumber;
        p.Address = vm.Address;
        p.Dni = vm.Dni;
        p.BirthDate = vm.BirthDate;
        p.IsSmoker = vm.IsSmoker;
        p.HasAllergies = vm.HasAllergies;
        p.UrlProfilePicture = vm.UrlProfilePicture;
            
        await _patientRepository.UpdateAsync(p);
    }
    
    public async Task Delete(int id)
    {
        var p = await _patientRepository.GetByIdAsync(id);
        await _patientRepository.DeleteAsync(p);
    }
    
    public async Task<SavePatientViewModel> GetByIdViewModel(int id)
    {
        Domain.Entities.Office.Patient p = await _patientRepository.GetByIdAsync(id);
        if (p == null) return null;

        SavePatientViewModel pVm = new()
        {
            Id = p.Id,
            Name = p.Name,
            LastName = p.LastName,
            Email = p.Email,
            PhoneNumber = p.PhoneNumber,
            Address = p.Address,
            Dni = p.Dni,
            BirthDate = p.BirthDate,
            IsSmoker = p.IsSmoker,
            HasAllergies = p.HasAllergies,
            DoctorOfficeId = p.IdDoctorOffice,
            UrlProfilePicture = p.UrlProfilePicture,
        };

        return pVm;
    }

    public async Task<List<PatientViewModel>> GetAllViewModel()
    {
        List<Domain.Entities.Office.Patient> p = await _patientRepository.GetAllAsync();
        List<PatientViewModel> pVms = new();

        foreach (var pVm in p)
        {
            PatientViewModel pVmss = new()
            {
                Id = pVm.Id,
                Name = pVm.Name,
                LastName = pVm.LastName,
                Email = pVm.Email,
                PhoneNumber = pVm.PhoneNumber,
                Address = pVm.Address,
                Dni = pVm.Dni,
                BirthDate = pVm.BirthDate,
                IsSmoker = pVm.IsSmoker,
                HasAllergies = pVm.HasAllergies,
                DoctorOfficeId = pVm.IdDoctorOffice,
                UrlProfilePicture = pVm.UrlProfilePicture,
                
            };

            pVms.Add(pVmss);
        }

        return pVms;
    }

    public async Task<List<PatientViewModel>> GetByDni(string cedula)
    {
        
        List<Domain.Entities.Office.Patient> p = await _patientRepository.GetByDni(cedula);
        List<PatientViewModel> pVms = new();

        foreach (var pVm in p)
        {
            PatientViewModel pVmss = new()
            {
                Id = pVm.Id,
                Name = pVm.Name,
                LastName = pVm.LastName,
                Email = pVm.Email,
                PhoneNumber = pVm.PhoneNumber,
                Address = pVm.Address,
                Dni = pVm.Dni,
                BirthDate = pVm.BirthDate,
                IsSmoker = pVm.IsSmoker,
                HasAllergies = pVm.HasAllergies,
                DoctorOfficeId = pVm.IdDoctorOffice,
                UrlProfilePicture = pVm.UrlProfilePicture,
                
            };

            pVms.Add(pVmss);
        }

        return pVms;
    }

}