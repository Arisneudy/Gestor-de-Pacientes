using GestorDePaciente.Core.Application.Interfaces.Repositories.Lab;
using GestorDePaciente.Core.Application.Interfaces.Services.Lab;
using GestorDePaciente.Core.Application.ViewModels.Lab.Test;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Application.Services.Lab;

public class LabTestService : ILabTestService
{
    
    private readonly ILabTestRepository _labTestRepository;

    public LabTestService(ILabTestRepository labTestRepository)
    {
        _labTestRepository = labTestRepository;
    }
    
    public async Task<SaveLabTestViewModel> Add(SaveLabTestViewModel vm)
    {
        LabTests labTests = new()
        {
            Name = vm.Name,
            IdDoctorOffice = vm.IdDoctorOffice,
            IdPatient = vm.IdPatient
        };
            
        await _labTestRepository.AddAsync(labTests);
            
        return vm;
    }
    
    public async Task Update(SaveLabTestViewModel vm)
    {
        LabTests lb = await _labTestRepository.GetByIdAsync(vm.Id);
        if (lb == null) return;

        lb.Name = vm.Name;
        
        await _labTestRepository.UpdateAsync(lb);
    }
    
    public async Task Delete(int id)
    {
        var lb = await _labTestRepository.GetByIdAsync(id);
        await _labTestRepository.DeleteAsync(lb);
    }
    
    public async Task<SaveLabTestViewModel> GetByIdViewModel(int id)
    {
        LabTests lb = await _labTestRepository.GetByIdAsync(id);
        if (lb == null) return null;

        SaveLabTestViewModel lbVm = new()
        {
            Id = lb.Id,
            Name = lb.Name,
            IdDoctorOffice = lb.IdDoctorOffice,
            IdPatient = lb.IdPatient
        };

        return lbVm;
    }

    public async Task<List<LabTestViewModel>> GetAllViewModel()
    {
        List<LabTests> lb = await _labTestRepository.GetAllAsync();
        List<LabTestViewModel> lbVms = new();

        foreach (var lbVm in lb)
        {
            LabTestViewModel lbVmss = new()
            {
                Id = lbVm.Id,
                Name = lbVm.Name,
                IdDoctorOffice = lbVm.IdDoctorOffice,
                IdPatient = lbVm.IdPatient
            };

            lbVms.Add(lbVmss);
        }

        return lbVms;
    }
}