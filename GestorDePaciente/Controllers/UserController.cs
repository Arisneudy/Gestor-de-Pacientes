using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Role;
using GestorDePaciente.Core.Application.Interfaces.Services.Users;
using GestorDePaciente.Core.Application.ViewModels.Users;
using GestorDePaciente.Core.Domain.Entities.Login;
using GestorDePaciente.Middlewares;
using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.ViewModels.Office.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class UserController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly IUserService _userService;
    private readonly IDoctorOfficeService _doctorOfficeService;
    private readonly IRoleService _roleService;

    public UserController(ValidateUserSession validate, IUserService userService,IDoctorOfficeService doctorOfficeService, IRoleService roleService)
    {
        _validate = validate;
        _userService = userService;
        _doctorOfficeService = doctorOfficeService;
        _roleService = roleService;
    }

    public async Task<IActionResult> User()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        var users = await _userService.GetAllViewModel();
        return View(users);
    }


    public async Task<IActionResult> Create(int idUsuario)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Roles = await _roleService.GetAllViewModel();
        
        if (idUsuario != 0)
        {
            var user = await _userService.GetByIdViewModel(idUsuario);
            return View("Create", user);
        }
        
        return View(new SaveUserViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveUserViewModel user)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Roles = await _roleService.GetAllViewModel();

        var userExistente = await _userService.GetByIdViewModel(user.Id);

        if (userExistente != null)
        {
            ModelState.AddModelError("userValidation", "Usuario ya existente");
            return View("Create", user);
        }
        
        if (user.Id == 0 )
        {
            await _userService.Add(user);
            return RedirectToRoute(new { Controller = "User", Action = "User" });
        }
     
        return View("Create");
    }

    public async Task<IActionResult> Edit(int idUsuario)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Roles = await _roleService.GetAllViewModel();
        
        var vm = await _userService.GetByIdViewModel(idUsuario);
        return View("Create", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SaveUserViewModel user)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Roles = await _roleService.GetAllViewModel();
        
        if (ModelState.IsValid && user.Id != 0)
        {
            await _userService.Update(user);
            return RedirectToRoute(new { Controller = "User", Action = "User" });
        }

        return View("Create", user);
    }

    public async Task<IActionResult> Delete(int idUsuario)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        var userActual = HttpContext.Session.Get<UserViewModel>("user");

        if (idUsuario != 0)
        {
            if(userActual.Id == idUsuario)
            {
                TempData["Error"] = "No se puede eliminar el usuario actual";
                return RedirectToRoute(new { Controller = "User", Action = "User" });
            }
            await _userService.Delete(idUsuario);
        }

        return RedirectToRoute(new { Controller = "User", Action = "User" });
    }
}