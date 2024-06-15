using GestorDePaciente.Core.Application.Interfaces.Repositories.Lab;
using GestorDePaciente.Core.Application.Interfaces.Services.Lab;
using GestorDePaciente.Core.Application.ViewModels.Lab.Result;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Application.Services.Lab;

public class ResultTestService : IResultTestService
{
    private readonly IResultTestRepository _resultTestRepository;

    public ResultTestService(IResultTestRepository resultTestRepository)
    {
        _resultTestRepository = resultTestRepository;
    }
    
    public async Task<SaveResultTestViewModel> Add(SaveResultTestViewModel vm)
    {
        ResultLabTest rt = new()
        {
            Result = vm.Result,
        };
            
        await _resultTestRepository.AddAsync(rt);
            
        return vm;
    }
    
    public async Task Update(SaveResultTestViewModel vm)
    {
        ResultLabTest rt = await _resultTestRepository.GetByIdAsync(vm.Id);
        if (rt == null) return;

        rt.Result = vm.Result;
        
        await _resultTestRepository.UpdateAsync(rt);
    }
    
    public async Task Delete(int id)
    {
        var rt = await _resultTestRepository.GetByIdAsync(id);
        await _resultTestRepository.DeleteAsync(rt);
    }

    public async Task<SaveResultTestViewModel> GetByIdViewModel(int id)
    {
        ResultLabTest rt = await _resultTestRepository.GetByIdAsync(id);
        if (rt == null) return null;

        SaveResultTestViewModel rtVm = new()
        {
            Result = rt.Result,
        };

        return rtVm;
    }

    public async Task<List<ResultTestViewModel>> GetAllViewModel()
    {
        List<ResultLabTest> rt = await _resultTestRepository.GetAllAsync();
        List<ResultTestViewModel> rtVms = new();

        foreach (var rtVm in rt)
        {
            ResultTestViewModel rtVmss = new()
            {
                Id = rtVm.Id,
                Result = rtVm.Result,
            };

            rtVms.Add(rtVmss);
        }

        return rtVms;
    }
    
    public async Task<List<ResultTestViewModel>> GetPendingTestsByUserId(int patientId)
    {
        List<ResultLabTest> rt = await _resultTestRepository.GetPendingTestsByUserId(patientId);
        List<ResultTestViewModel> rtVms = new();

        foreach (var rtVm in rt)
        {
            ResultTestViewModel rtVmss = new()
            {
                Id = rtVm.Id,
                Result = rtVm.Result,
            };

            rtVms.Add(rtVmss);
        }

        return rtVms;
    }
    
    public async Task ReportResult(int idLabTest, string result)
    {
        ResultLabTest rt = await _resultTestRepository.GetByIdAsync(idLabTest);
        if (rt == null) return;

        rt.Result = result;
        
        await _resultTestRepository.UpdateAsync(rt);
    }
    
}