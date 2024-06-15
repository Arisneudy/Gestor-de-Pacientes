using GestorDePaciente.Core.Application.Interfaces.Repositories.Role;
using GestorDePaciente.Core.Application.Interfaces.Services.Role;
using GestorDePaciente.Core.Application.ViewModels.Role;

namespace GestorDePaciente.Core.Application.Services.Role;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    
    public async Task<SaveRoleViewModel> Add(SaveRoleViewModel vm)
    {
        Domain.Entities.Role.Role r = new()
        {
            Name = vm.Name,
        };
            
        await _roleRepository.AddAsync(r);
            
        return vm;
    }
    
    public async Task Update(SaveRoleViewModel vm)
    {
        Domain.Entities.Role.Role r = await _roleRepository.GetByIdAsync(vm.Id);
        if (r == null) return;

        r.Name = vm.Name;
        
        await _roleRepository.UpdateAsync(r);
    }
    
    public async Task Delete(int id)
    {
        var r = await _roleRepository.GetByIdAsync(id);
        await _roleRepository.DeleteAsync(r);
    }
    
    public async Task<SaveRoleViewModel> GetByIdViewModel(int id)
    {
        Domain.Entities.Role.Role r = await _roleRepository.GetByIdAsync(id);
        if (r == null) return null;

        SaveRoleViewModel rVm = new()
        {
            Name = r.Name,
        };

        return rVm;
    }

    public async Task<List<RoleViewModel>> GetAllViewModel()
    {
        List<Domain.Entities.Role.Role> r = await _roleRepository.GetAllAsync();
        List<RoleViewModel> rVms = new();

        foreach (var doctorVm in r)
        {
            RoleViewModel rVmss = new()
            {
                Id = doctorVm.Id,
                Name = doctorVm.Name,
            };

            rVms.Add(rVmss);
        }

        return rVms;
    }
}