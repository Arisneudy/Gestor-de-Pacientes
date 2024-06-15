using GestorDePaciente.Core.Application.Interfaces.Services.Lab;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels;
using GestorDePaciente.Core.Application.ViewModels.Office.Patient;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class ResultLabTestController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly IPatientService _patientService;
    private readonly ILabTestService _labTestService;
    
    public ResultLabTestController(ValidateUserSession validate, IResultTestService resultTestService, IPatientService patientService, ILabTestService labTestService)
    {
        _validate = validate;
        _patientService = patientService;
        _labTestService = labTestService;
    }
    
    public async Task<ActionResult> ResultLabTest(FiltroViewModel filtro, string cedula)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.Patients = await _patientService.GetAllViewModel();
        ViewBag.LabTest = await _labTestService.GetAllViewModel();
        
        var patients = await _patientService.GetAllViewModel();

        if (cedula != null)
        {
            patients = await _patientService.GetByDni(cedula);
        }
        return View(patients);
    }
}