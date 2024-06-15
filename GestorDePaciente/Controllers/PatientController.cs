using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels.Office.Patient;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class PatientController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly IPatientService _patientService;
    private readonly IDoctorOfficeService _doctorOfficeService;
    
    public PatientController(ValidateUserSession validate, IPatientService patientService, IDoctorOfficeService doctorOfficeService)
    {
        _validate = validate;
        _patientService = patientService;
        _doctorOfficeService = doctorOfficeService;
    }
    
    public async Task<IActionResult> Patient()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        var patients = await _patientService.GetAllViewModel();
        return View(patients);
    }
    
    public async Task<IActionResult> Create(int idPatient)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        
        if (idPatient != 0)
        {
            var patient = await _patientService.GetByIdViewModel(idPatient);
            return View("Create", patient);
        }
        
        return View(new SavePatientViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(SavePatientViewModel patient)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();

        var pacienteExistente = await _patientService.GetByIdViewModel(patient.Id);

        if (pacienteExistente != null)
        {
            ModelState.AddModelError("patientValidation", "Paciente ya existente");
            return View("Create", patient);
        }

        
        if (patient.Id == 0 )
        {
            SavePatientViewModel p = await _patientService.Add(patient);
            
            p.UrlProfilePicture = UploadsFile.UploadImage(patient.ProfilePicture, p.Id, "patient");
            await _patientService.Update(p);
            return RedirectToRoute(new { Controller = "Patient", Action = "Patient" });
        }
     
        return View("Create");
    }

    public async Task<IActionResult> Edit(int idPatient)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        
        var vm = await _patientService.GetByIdViewModel(idPatient);
        return View("Create", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SavePatientViewModel patient)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();

        if (ModelState.IsValid)
        {
            var p = await _patientService.GetByIdViewModel(patient.Id);
            patient.UrlProfilePicture = UploadsFile.UploadImage(patient.ProfilePicture, patient.Id, "patient", true, p.UrlProfilePicture!);

            if (patient.Id != 0)
            {
                await _patientService.Update(patient);
                return RedirectToRoute(new { Controller = "Patient", Action = "Patient" });
            }
        }
        

        return View("Create", patient);
    }

    public async Task<IActionResult> Delete(int idPatient)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        if (idPatient != 0)
        {
            await _patientService.Delete(idPatient);
        }

        return RedirectToRoute(new { Controller = "Patient", Action = "Patient" });
    }
}