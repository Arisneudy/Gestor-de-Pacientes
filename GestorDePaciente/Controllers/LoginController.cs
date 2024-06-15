using GestorDePaciente.Core.Application.Interfaces.Services.Login;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.ViewModels.Login;
using GestorDePaciente.Middlewares;
using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IDoctorOfficeService _doctorOfficeService;
        private readonly ValidateUserSession _validate;


        public LoginController(ILoginService loginService, IDoctorOfficeService doctorOfficeService, ValidateUserSession validate)
        {
            _loginService = loginService;
            _doctorOfficeService = doctorOfficeService;
            _validate = validate;
        }

        public ActionResult Index()
        {
            if (_validate.HasUser())
            {
                return RedirectToRoute(new { Controller = "Home", Action = "Home" });
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel vm)
        {
            if (_validate.HasUser())
            {
                return RedirectToRoute(new { Controller = "Home", Action = "Home" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            UserViewModel userVm = await _loginService.Login(vm);

            if (userVm != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
                return RedirectToRoute(new { Controller = "Home", Action = "Home" });
            }

            ModelState.AddModelError("userValidation", "Datos de acceso incorrecto");
            return View(vm);
        }

        public async Task<ActionResult> Register()
        {
            if (_validate.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Home" });
            }
            ViewBag.doctorOffices = await _doctorOfficeService.GetAllViewModel();
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel vm)
        {
            if (_validate.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Home" });
            }
            ViewBag.doctorOffices = await _doctorOfficeService.GetAllViewModel();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var usuarioExistente = await _loginService.GetByUserName(vm.UserName);

            if (usuarioExistente != null)
            {
                ModelState.AddModelError("userValidation", "Usuario ya existente");
                return View(vm);
            }
            await _loginService.Add(vm);
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }
}
