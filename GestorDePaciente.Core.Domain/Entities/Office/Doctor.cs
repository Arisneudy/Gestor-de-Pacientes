﻿using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Lab;

namespace GestorDePaciente.Core.Domain.Entities.Office;

public class Doctor : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Dni { get; set; }
    public string? UrlProfilePicture { get; set; }
    
    public int IdDoctorOffice { get; set; }
    public DoctorOffice DoctorOffice { get; set; }
    
    public ICollection<Appointment>? Appointments { get; set; }
    
}