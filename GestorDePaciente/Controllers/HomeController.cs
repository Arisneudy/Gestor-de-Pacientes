using GestorDePaciente.Core.Application.Interfaces.Services.Login;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;
public class HomeController : Controller
{

    private readonly ValidateUserSession _validate;

    public HomeController(ValidateUserSession validate)
    {
        _validate = validate;
    }
    
    public ActionResult Home()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        return View();
    }
}