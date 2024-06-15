using GestorDePaciente.Core.Application.Interfaces.Services.General;
using GestorDePaciente.Core.Application.ViewModels.Lab.Result;

namespace GestorDePaciente.Core.Application.Interfaces.Services.Lab;

public interface IResultTestService : IGenericService<SaveResultTestViewModel, ResultTestViewModel>
{
    Task<List<ResultTestViewModel>> GetPendingTestsByUserId(int patientId);
    Task ReportResult(int idLabTest, string result);
}