namespace GestorDePaciente.Core.Application.Interfaces.Services.General;

public interface IGenericService<SaveViewModel, ViewModel> where SaveViewModel : class where ViewModel : class
{
    Task<SaveViewModel> Add(SaveViewModel vm);
    Task Update(SaveViewModel vm);
    Task Delete(int id);
    Task<SaveViewModel> GetByIdViewModel(int id);
    Task<List<ViewModel>> GetAllViewModel();  
} 