using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;
using Microsoft.AspNetCore.Http;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Doctor;

public class SaveDoctorViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo Nombre es requerido")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "El campo Apellido es requerido")]
    [DataType(DataType.Text)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "El campo Email es requerido")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "El campo Teléfono es requerido")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una oficina de doctor")]
    public int DoctorOfficeId { get; set; }
    
    [Required(ErrorMessage = "El campo DNI es requerido")]
    [DataType(DataType.Text)]
    public string Dni { get; set; }
    
    [DataType(DataType.ImageUrl)]
    public string? UrlProfilePicture { get; set; }
    
    [DataType(DataType.Upload)]
    public IFormFile ProfilePicture { get; set; }
}