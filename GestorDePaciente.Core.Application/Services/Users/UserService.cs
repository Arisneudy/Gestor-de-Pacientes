using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.Interfaces.Repositories.Users;
using GestorDePaciente.Core.Application.Interfaces.Services.Users;
using GestorDePaciente.Core.Application.ViewModels.Users;
using GestorDePaciente.Core.Domain.Entities.Login;
using Microsoft.AspNetCore.Http;

namespace GestorDePaciente.Core.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;

        public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext?.Session?.Get<UserViewModel>("user")!;
        }

        public async Task<UserViewModel> GetByUserName(string userName)
        {
            User user = await _userRepository.GetByUserNameAsync(userName);

            if (user == null || _userViewModel == null)
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
                DoctorOfficeId = _userViewModel.DoctorOfficeId,
                DoctorOffice = _userViewModel.DoctorOffice,
                RoleId = user.RoleId
            };

            return userVm;
        }
        
        public async Task Update(SaveUserViewModel vm)
        {
            User user = await _userRepository.GetByIdAsync(vm.Id);
            if (user == null) return;

            user.Name = vm.Name;
            user.LastName = vm.LastName;
            user.Email = vm.Email;
            user.Password = vm.Password;
            user.RoleId = vm.RoleId;

            await _userRepository.UpdateAsync(user);
        }
        
        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            var userExist = await _userRepository.GetByUserNameAsync(vm.UserName);

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

            await _userRepository.AddAsync(user);

            return vm;
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return;

            await _userRepository.DeleteAsync(user);
        }

        public async Task<SaveUserViewModel> GetByIdViewModel(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            SaveUserViewModel userVm = new()
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
            if (_userViewModel == null)
            {
                return new List<UserViewModel>();
            }

            List<User> users = await _userRepository.GetAllWithInclude(new List<string> { "DoctorOffice" });
            List<UserViewModel> userVms = users
                .Where(u => u.DoctorOfficeId == _userViewModel.DoctorOfficeId)
                .Select(user => new UserViewModel
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
}
