using GestorDePaciente.Core.Application.Interfaces.Services.Lab;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels.Lab.Test;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class LabTestController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly ILabTestService _labTestService;
    private readonly IDoctorOfficeService _doctorOfficeService;
    private readonly IPatientService _patientService;
    
    public LabTestController(ValidateUserSession validate, ILabTestService labTestService, IDoctorOfficeService doctorOfficeService, IPatientService patientService)
    {
        _validate = validate;
        _labTestService = labTestService;
        _doctorOfficeService = doctorOfficeService;
        _patientService = patientService;
    }

    public async Task<ActionResult> LabTest()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        ViewBag.Patients = await _patientService.GetAllViewModel();
        var lbt = await _labTestService.GetAllViewModel();
        return View(lbt);
    }


    public async Task<ActionResult> Create(int idLabTest)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        if (idLabTest != 0)
        {
            var lbt = await _labTestService.GetByIdViewModel(idLabTest);
            return View("Create", lbt);
        }
        
        return View(new SaveLabTestViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveLabTestViewModel lbt)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        if (lbt.Id == 0 )
        {
            await _labTestService.Add(lbt);
            return RedirectToRoute(new { Controller = "LabTest", Action = "LabTest" });
        }
     
        return View("Create");
    }

    public async Task<ActionResult> Edit(int idLabTest)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        var vm = await _labTestService.GetByIdViewModel(idLabTest);
        return View("Create", vm);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(SaveLabTestViewModel lbt)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        if (ModelState.IsValid)
        {
            await _labTestService.Update(lbt);
            return RedirectToRoute(new { Controller = "LabTest", Action = "LabTest" });
        }

        return View("Create", lbt);
    }

    public async Task<ActionResult> Delete(int idLabTest)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        if (idLabTest != 0)
        {
            await _labTestService.Delete(idLabTest);
        }

        return RedirectToRoute(new { Controller = "LabTest", Action = "LabTest" });
    }
}