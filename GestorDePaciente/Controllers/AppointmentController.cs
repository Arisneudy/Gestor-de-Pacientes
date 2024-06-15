using GestorDePaciente.Core.Application.Helpers;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Appointment;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Doctor;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.DoctorOffice;
using GestorDePaciente.Core.Application.Interfaces.Services.Office.Patient;
using GestorDePaciente.Core.Application.ViewModels.Office.Appointment;
using GestorDePaciente.Core.Application.ViewModels.Office.Patient;
using GestorDePaciente.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorDePaciente.Controllers;

public class AppointmentController : Controller
{
    private readonly ValidateUserSession _validate;
    private readonly IAppointmentsService _appointmentsService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;
    private readonly IDoctorOfficeService _doctorOfficeService;
    
    public AppointmentController(ValidateUserSession validate, IAppointmentsService appointmentsService, IPatientService patientService, IDoctorService doctorService, IDoctorOfficeService doctorOfficeService)
    {
        _validate = validate;
        _patientService = patientService;
        _doctorService = doctorService;
        _appointmentsService = appointmentsService;
        _doctorOfficeService = doctorOfficeService;
    }
    
    public async Task<IActionResult> Appointment()
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Doctors = await _doctorService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        var appointment = await _appointmentsService.GetAllViewModel();
        return View(appointment);
    }
    
    public async Task<IActionResult> Create(int idCita)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Doctors = await _doctorService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        if (idCita != 0)
        {
            var appointment = await _appointmentsService.GetByIdViewModel(idCita);
            return View("Create", appointment);
        }
        
        return View(new SaveAppointmentViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveAppointmentViewModel appointment)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Doctors = await _doctorService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        var citaExistente = await _patientService.GetByIdViewModel(appointment.Id);

        if (citaExistente != null)
        {
            ModelState.AddModelError("appointmentValidation", "Cita ya existente");
            return View("Create", appointment);
        }

        
        if (appointment.Id == 0 )
        {
            await _appointmentsService.Add(appointment);
            return RedirectToRoute(new { Controller = "Appointment", Action = "Appointment" });
        }
     
        return View("Create");
    }

    public async Task<IActionResult> Edit(int idCita)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Doctors = await _doctorService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        var vm = await _appointmentsService.GetByIdViewModel(idCita);
        return View("Create", vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SaveAppointmentViewModel appointment)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }

        ViewBag.DoctorOffices = await _doctorOfficeService.GetAllViewModel();
        ViewBag.Doctors = await _doctorService.GetAllViewModel();
        ViewBag.Patients = await _patientService.GetAllViewModel();
        
        if (ModelState.IsValid && appointment.Id != 0)
        {
            await _appointmentsService.Update(appointment);
            return RedirectToRoute(new { Controller = "Appointment", Action = "Appointment" });
        }
        return View("Create", appointment);
    }

    public async Task<IActionResult> Delete(int idCita)
    {
        if (!_validate.HasUser())
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
        
        if (idCita != 0)
        {
            await _appointmentsService.Delete(idCita);
        }

        return RedirectToRoute(new { Controller = "Appointment", Action = "Appointment" });
    }
}