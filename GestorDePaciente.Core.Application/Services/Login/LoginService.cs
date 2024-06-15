using GestorDePaciente.Core.Application.Interfaces.Repositories;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Login;
using GestorDePaciente.Core.Application.Interfaces.Services.Login;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Domain.Entities.Login;
using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Http;

namespace GestorDePaciente.Core.Application.Services.Login;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;

    public LoginService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }
        
    public async Task<UserViewModel> Login(LoginViewModel vm)
    {
        User user = await _loginRepository.LoginAsync(vm);

        if (user == null)
        {
            return null;
        }

        UserViewModel userVm = new()
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.UserName,
            LastName = user.LastName,
            Password = user.Password,
            Email = user.Email,
            DoctorOfficeId = user.DoctorOfficeId,
            DoctorOffice = user.DoctorOffice,
            RoleId = user.RoleId
        };

        return userVm;
    }
        
    
    public async Task<UserViewModel> GetByUserName(string userName)
    {
        User user = await _loginRepository.GetByUserNameAsync(userName);

        if (user == null)
        {
            return null;
        }

        UserViewModel userVm = new()
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.UserName,
            Password = user.Password,
            Email = user.Email,
            DoctorOfficeId = user.DoctorOfficeId,
            DoctorOffice = user.DoctorOffice,
            RoleId = user.RoleId
        };

        return userVm;
    }
    
    
    public async Task Update(RegisterViewModel vm)
    {
        User user = await _loginRepository.GetByIdAsync(vm.Id);
        if (user == null) return;

        user.Name = vm.Name;
        user.UserName = vm.UserName;
        user.LastName = vm.LastName;
        user.Email = vm.Email;
        user.DoctorOfficeId = vm.DoctorOfficeId;
        user.Password = vm.Password;

        await _loginRepository.UpdateAsync(user);
    }
        
    public async Task<RegisterViewModel> Add(RegisterViewModel vm)
    {
        var userExist = await _loginRepository.GetByUserNameAsync(vm.UserName);
        
        if (userExist != null)
        {
            return null;
        }
        
        User user = new()
        {
            Name = vm.Name,
            UserName = vm.UserName,
            LastName = vm.LastName,
            Email = vm.Email,
            DoctorOfficeId = vm.DoctorOfficeId,
            Password = vm.Password,
            RoleId = vm.RoleId
        };
            
        await _loginRepository.AddAsync(user);
            
        return vm;
    }
        
    public async Task Delete(int id)
    {
        var user = await _loginRepository.GetByIdAsync(id);
        await _loginRepository.DeleteAsync(user);
    }
    
    public async Task<RegisterViewModel> GetByIdViewModel(int id)
    {
        User user = await _loginRepository.GetByIdAsync(id);
        if (user == null) return null;

        RegisterViewModel userVm = new()
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.UserName,
            LastName = user.LastName,
            Email = user.Email,
            DoctorOfficeId = user.DoctorOfficeId,
            Password = user.Password,
            RoleId = user.RoleId
        };

        return userVm;
    }
    
    public async Task<List<UserViewModel>> GetAllViewModel()
    {
        List<User> users = await _loginRepository.GetAllWithInclude(new List<string>{"DoctorOffice"});
        List<UserViewModel> userVms = new();
        userVms = users.Select(user => new UserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.UserName,
            LastName = user.LastName,
            Email = user.Email,
            DoctorOfficeId = user.DoctorOfficeId,
            DoctorOffice = user.DoctorOffice,
            Password = user.Password,
            RoleId = user.RoleId
        }).ToList();

        return userVms;
    }
}