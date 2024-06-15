using GestorDePaciente.Core.Domain.Common;
using GestorDePaciente.Core.Domain.Entities.Office;

namespace GestorDePaciente.Core.Domain.Entities.Lab;

public class LabTests : BaseEntity
{
    public string Name { get; set; }
    public int IdDoctorOffice { get; set; }
    public int IdPatient { get; set; }
    
    public DoctorOffice DoctorOffice { get; set; }
    public Patient Patient { get; set; }
    
    public ICollection<ResultLabTest> ResultLabTests { get; set; }
}