using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.ViewModels.Users;

namespace GestorDePaciente.Middlewares;

public class ValidateUserSession
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public bool HasUser()
    {
        UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");

        if (userViewModel == null)
        {
            return false;
        }
        return true;
    }
    
}