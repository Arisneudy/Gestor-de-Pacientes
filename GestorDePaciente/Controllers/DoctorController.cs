using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Doctor;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Role;
using GestorDePaciente.Core.Application.Interfaces.Services.Users;
using GestorDePaciente.Core.Application.ViewModels.Office.Doctor;
using GestorDePaciente.Core.Application.ViewModels.Users;
using GestorDePaciente.Core.Domain.Entities.Office;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class DoctorController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly IDoctorService _doctorService;
    private readonly IDoctorOfficeService _doctorOfficeService;

    public DoctorController(ValidateUserSession validate, IDoctorService doctorService, IDoctorOfficeService doctorOfficeService)
    {
        _validate = validate;
        _doctorService = doctorService;
        _doctorOfficeService = doctorOfficeService;
    }

    public async Task<IActionResult> Doctor()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        var doctors = await _doctorService.GetAllViewModel();
        return View(doctors);
    }


    public async Task<IActionResult> Create(int idDoctor)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        
        if (idDoctor != 0)
        {
            var doctor = await _doctorService.GetByIdViewModel(idDoctor);
            return View("Create", doctor);
        }
        
        return View(new SaveDoctorViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveDoctorViewModel doctor)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();

        var doctorExistente = await _doctorService.GetByIdViewModel(doctor.Id);

        if (doctorExistente != null)
        {
            ModelState.AddModelError("doctorValidation", "Doctor ya existente");
            return View("Create", doctor);
        }

        
        if (doctor.Id == 0 )
        {
            SaveDoctorViewModel dvm = await _doctorService.Add(doctor);
            
            dvm.UrlProfilePicture = UploadsFile.UploadImage(doctor.ProfilePicture, dvm.Id, "doctor");
            await _doctorService.Update(dvm);
            return RedirectToRoute(new { Controller = "Doctor", Action = "Doctor" });
        }
     
        return View("Create");
    }

    public async Task<IActionResult> Edit(int idDoctor)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        
        SaveDoctorViewModel vm = await _doctorService.GetByIdViewModel(idDoctor);
        return View("Create", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SaveDoctorViewModel doctor)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        
        if (ModelState.IsValid)
        {
            var dvm = await _doctorService.GetByIdViewModel(doctor.Id);
            doctor.UrlProfilePicture = UploadsFile.UploadImage(doctor.ProfilePicture, doctor.Id, "doctor", true, dvm.UrlProfilePicture!);

            if (doctor.Id != 0)
            {
                await _doctorService.Update(doctor);
                return RedirectToRoute(new { Controller = "Doctor", Action = "Doctor" });
            }
        }

        return View("Create", doctor);
    }

    public async Task<IActionResult> Delete(int idDoctor)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        if (idDoctor != 0)
        {
            await _doctorService.Delete(idDoctor);
        }

        return RedirectToRoute(new { Controller = "Doctor", Action = "Doctor" });
    }
}