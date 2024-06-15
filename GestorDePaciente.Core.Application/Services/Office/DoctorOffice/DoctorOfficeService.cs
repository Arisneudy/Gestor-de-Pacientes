using GestorDePaciente.Core.Application.Interfaces.Repositories.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.ViewModels.Office;

namespace GestorDePaciente.Core.Application.Services.Office.DoctorOffice;

public class DoctorOfficeService : IDoctorOfficeService
{

    private readonly IDoctorOfficeRepository _doctorOfficeRepository;
    
    public DoctorOfficeService(IDoctorOfficeRepository doctorOfficeRepository)
    {
        _doctorOfficeRepository = doctorOfficeRepository;
    }
    
    public async Task<SaveDoctorOfficeViewModel> Add(SaveDoctorOfficeViewModel vm)
    {
        Domain.Entities.Office.DoctorOffice doctorOffice = new()
        {
            Name = vm.Name,
            Address = vm.Address
        };
            
        await _doctorOfficeRepository.AddAsync(doctorOffice);
            
        return vm;
    }
    
    public async Task Update(SaveDoctorOfficeViewModel vm)
    {
        Domain.Entities.Office.DoctorOffice doctorOffice = await _doctorOfficeRepository.GetByIdAsync(vm.Id);
        if (doctorOffice == null) return;

        doctorOffice.Name = vm.Name;
        doctorOffice.Address = vm.Address;
        
        await _doctorOfficeRepository.UpdateAsync(doctorOffice);
    }
    
    public async Task Delete(int id)
    {
        var doctorOffice = await _doctorOfficeRepository.GetByIdAsync(id);
        await _doctorOfficeRepository.DeleteAsync(doctorOffice);
    }
    
    public async Task<SaveDoctorOfficeViewModel> GetByIdViewModel(int id)
    {
        Domain.Entities.Office.DoctorOffice doctorOffice = await _doctorOfficeRepository.GetByIdAsync(id);
        if (doctorOffice == null) return null;

        SaveDoctorOfficeViewModel doctorOfficeVm = new()
        {
            Id = doctorOffice.Id,
            Name = doctorOffice.Name,
            Address = doctorOffice.Address
        };

        return doctorOfficeVm;
    }

    public async Task<List<DoctorOfficeViewModel>> GetAllViewModel()
    {
        List<Domain.Entities.Office.DoctorOffice> doctorOffices = await _doctorOfficeRepository.GetAllAsync();
        List<DoctorOfficeViewModel> doctorOVms = new();

        foreach (var doctorOfficeVm in doctorOffices)
        {
            DoctorOfficeViewModel doctorOVm = new()
            {
                Id = doctorOfficeVm.Id,
                Name = doctorOfficeVm.Name,
                Address = doctorOfficeVm.Address
            };

            doctorOVms.Add(doctorOVm);
        }

        return doctorOVms;
    }
    
}