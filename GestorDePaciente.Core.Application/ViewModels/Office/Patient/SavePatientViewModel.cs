using System.ComponentModel.DataAnnotations;
using GestorDePaciente.Core.Application.ViewModels.Common;
using Microsoft.AspNetCore.Http;

namespace GestorDePaciente.Core.Application.ViewModels.Office.Patient;

public class SavePatientViewModel : BaseVM
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Text)]
    public string Dni { get; set; }
    
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    public bool IsSmoker { get; set; }
    public bool HasAllergies { get; set; }
    
    [DataType(DataType.ImageUrl)]
    public string? UrlProfilePicture { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "El campo es requerido")]    
    public int DoctorOfficeId { get; set; }
    
    [DataType(DataType.Upload)]
    public IFormFile ProfilePicture { get; set; }
    
}